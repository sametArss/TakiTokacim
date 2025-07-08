using EntitiyLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using DataAcsessLayer.Abstract;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusiniessLayer.Abstract;
using System.Collections.Generic;

namespace TakiTokacim.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly ICartDal _cartDal;
        private readonly ICartItemsDal _cartItemsDal;
        private readonly IUserAdressDal _userAdressDal;
        private readonly IPaymentService _paymentService;
        private readonly IAdressService _adressService;
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;

        public OrderController(IAdressService adressService, IUserService userService, IPaymentService paymentService, IOrderService orderService, ICartService cartService, ICartItemService cartItemService)
        {
            
             _orderService = orderService;
            _cartService = cartService;
            _cartItemService = cartItemService; 
            _paymentService = paymentService;
            _adressService = adressService;
            _userService = userService;

        }

        public IActionResult Index()
        {
            // Kullanıcının siparişlerini listeleyecek
            return View();
        }

        public IActionResult Details(string id)
        {
            // Sipariş detaylarını gösterecek
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var userId = _userService.GetUserId(User);
            var adresler = (_adressService.GetAdresses(User) ?? new List<UserAdress>())
                .Where(x => x != null && x.AdressId != 0 && !string.IsNullOrEmpty(x.AdressTitle))
                .Select(x => new SelectListItem { Value = x.AdressId.ToString(), Text = x.AdressTitle })
                .ToList();
            adresler.Add(new SelectListItem { Value = "add", Text = "➕ Adres Ekle" });
            ViewBag.Adresler = adresler;

            var kartlar = (_paymentService.GetListByUser(User) ?? new List<Payment>())
                .Where(x => x != null && x.PaymentId != 0 && !string.IsNullOrEmpty(x.PaymentName))
                .Select(x => new SelectListItem { Value = x.PaymentId.ToString(), Text = x.PaymentName })
                .ToList();
            kartlar.Add(new SelectListItem { Value = "add", Text = "➕ Kart Ekle" });
            ViewBag.Kartlar = kartlar;

            var cart = _cartService.UserActiveCart(User);
            if (cart != null)
            {
                var cartItems = _cartItemService.GetAllCartId(cart.CartId);
                ViewBag.CartItems = cartItems;
                ViewBag.CartTotal = cartItems.Sum(x => x.TotalPrice);
            }
            else
            {
                ViewBag.CartItems = new List<CartItem>();
                ViewBag.CartTotal = 0;
            }
            return View(new OrderViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userService.GetUserId(User);
                var order = new Order
                {
                    FullName = model.FullName,
                    PhoneNum = model.PhoneNum,
                    UserAdressId = model.AdressId,
                    PaymentId = model.PaymentId,
                    Description = model.Description,
                    UserId = userId,
                    OrderDate = DateTime.Now,
                    TotalAmount = model.TotalAmount
                };
                var cart = _cartService.UserActiveCart(User);
                if (cart != null)
                {
                    order.CartId = cart.CartId;
                    order.TotalAmount=model.TotalAmount;
                }
                _orderService.Insert(order);
                TempData["Success"] = "Siparişiniz başarıyla oluşturuldu.";
                _cartService.Update(cart);
                return RedirectToAction("MyOrders");
            }
            // Hatalı alanları Türkçe olarak topla ve TempData ile view'a gönder
            var hataListesi = new List<string>();
            foreach (var key in ModelState.Keys)
            {
                var state = ModelState[key];
                foreach (var error in state.Errors)
                {
                    hataListesi.Add($"{key.Replace(".", " → ")}: {error.ErrorMessage}");
                }
            }
            if (hataListesi.Any())
            {
                TempData["ModelErrors"] = string.Join("<br>", hataListesi);
            }
            // ViewBag doldurma kodları tekrar
            var userId2 = _userService.GetUserId(User);
            var adresler2 = (_adressService.GetAdresses(User) ?? new List<UserAdress>())
                .Where(x => x != null && x.AdressId != 0 && !string.IsNullOrEmpty(x.AdressTitle))
                .Select(x => new SelectListItem { Value = x.AdressId.ToString(), Text = x.AdressTitle })
                .ToList();
            adresler2.Add(new SelectListItem { Value = "add", Text = "➕ Adres Ekle" });
            ViewBag.Adresler = adresler2;

            var kartlar2 = (_paymentService.GetListByUser(User) ?? new List<Payment>())
                .Where(x => x != null && x.PaymentId != 0 && !string.IsNullOrEmpty(x.PaymentName))
                .Select(x => new SelectListItem { Value = x.PaymentId.ToString(), Text = x.PaymentName })
                .ToList();
            kartlar2.Add(new SelectListItem { Value = "add", Text = "➕ Kart Ekle" });
            ViewBag.Kartlar = kartlar2;

            var cart2 = _cartService.UserActiveCart(User);
            if (cart2 != null)
            {
                var cartItems = _cartItemService.GetAllCartId(cart2.CartId);
                ViewBag.CartItems = cartItems;
                ViewBag.CartTotal = cartItems.Sum(x => x.TotalPrice);
            }
            else
            {
                ViewBag.CartItems = new List<CartItem>();
                ViewBag.CartTotal = 0;
            }
            return View(model);
        }


        public IActionResult MyOrders()
        {
            var userId = _userService.GetUserId(User);
            var values = _orderService.OrderList(User); 

            if(values == null || !values.Any())
            {
                TempData["OrderMessage"] = "Siparişiniz yoktur.";
                return View();
            }
            else
            {
                return View(values);
            }
        }
    }
} 