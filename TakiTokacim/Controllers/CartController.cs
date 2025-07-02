using BusiniessLayer.Abstract;
using EntitiyLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TakiTokacim.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IUserService _userService;
        private readonly ICartItemService _cartItemService;


        public CartController(ICartService cartService, IUserService userService, ICartItemService cartItemService)
        {
            _cartService = cartService;
            _userService = userService;
            _cartItemService = cartItemService;
        }


        public IActionResult Index() {

            var cart = _cartService.UserActiveCart(User);

            if (cart == null) {

                // Sepetiniz Boş Hadi Alışverişe başlayalım 
                return View();
            }

            else
            {
              var cartItems= _cartItemService.GetAllCartId(cart.CartId);
             return View(cartItems);
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult CartControl(CartItem cartItem)
        {
            var cart = _cartService.UserActiveCart(User);
            if (cart == null) {
                var cartAdd = new Cart
                {
                    UserId = _userService.GetUserId(User),
                    Date = DateTime.Now,
                    CartStatus = true
                };
                _cartService.Insert(cartAdd);
                cartItem.CartId = cartAdd.CartId;
                cartItem.TotalPrice = cartItem.Quantity * cartItem.UnitPrice;
                _cartItemService.Insert(cartItem);
            }
            else
            {
                var cartItemControl = _cartItemService.CartItemControl(cartItem.ProductId, cartItem.CartId);
                if (cartItemControl == null)
                {
                    cartItem.CartId = cart.CartId;
                    cartItem.TotalPrice = cartItem.Quantity * cartItem.UnitPrice;
                    _cartItemService.Insert(cartItem);
                }
                else {
                    cartItemControl.Quantity += cartItem.Quantity;
                    cartItemControl.Date = DateTime.Now;
                    cartItemControl.TotalPrice = cartItemControl.Quantity * cartItemControl.UnitPrice;
                    _cartItemService.Update(cartItemControl);
                }
            }
            TempData["CartSuccess"] = "Ürününüz sepete eklenmiştir";
            return RedirectToAction("Details", "Products", new { id = cartItem.ProductId });
        }

        [HttpPost]
        [Authorize]
        public IActionResult UpdateQuantity(int cartItemId, string operation)
        {
            var cartItem = _cartItemService.GetCartItemByID(cartItemId);
            if (cartItem != null)
            {
                if (operation == "increase")
                    cartItem.Quantity++;
                else if (operation == "decrease" && cartItem.Quantity > 1)
                    cartItem.Quantity--;

                cartItem.TotalPrice = cartItem.Quantity * cartItem.UnitPrice;
                _cartItemService.Update(cartItem);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        [Authorize]
        public IActionResult DeleteItem(int id)
        {
            var deleteCartItem = _cartItemService.GetCartItemByID(id);
            if (deleteCartItem != null)
            {
                _cartItemService.Delete(deleteCartItem);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }




    }
} 