using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EntitiyLayer.Models;
using TakiTokacim.Models;
using Microsoft.AspNetCore.Authorization;
using DataAcsessLayer.Abstract;
using BusiniessLayer.Abstract;

namespace TakiTokacim.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAdressService _adressService;
        private readonly IPaymentService _paymentService;


        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IAdressService adressService , IPaymentService paymentService)
        {
            _adressService =adressService;
            _userManager = userManager;
            _signInManager = signInManager;
            _paymentService = paymentService;
           
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                    UserLName = model.UserLName,
                    CreateDateTime = DateTime.Now,
                    UserStatus = true
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    TempData["RegisterSuccess"] = "Kayıtınız başarılı bir şekilde yapılmıştır. Alışverişe başlayalım.";
                    return RedirectToAction("Login", "Account");
                }
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");

                ModelState.AddModelError("", "Giriş başarısız e-posta ve şifre yanlış. ");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> MyAccount()
        {
            var user = await _userManager.GetUserAsync(User);
            //var adresses = user.UserAdresses?.ToList() ?? new List<UserAdress>();
            var payments = user.Payments?.ToList() ?? new List<Payment>();
            ViewBag.adress = _adressService.GetAdresses(User);
            var model = new MyAccountViewModel
            {
                Email = user.Email,
                UserLName = user.UserLName,
                Adresses = ViewBag.adress,
                Payments = payments
            };
            ViewBag.adress = _adressService.GetAdresses(User);
            ViewBag.payments = _paymentService.GetListByUser(User);
            return View(model);
        }

       

        //[Authorize]
        //[HttpGet]
        //public IActionResult AddCard()
        //{
        //    return View();
        //}

        //[Authorize]
        //[HttpPost]
        //public async Task<IActionResult> AddCard(AddCardViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.GetUserAsync(User);
        //        var card = new Payment
        //        {
        //            PaymentName = model.PaymentName,
        //            CardNumber = model.CardNumber,
        //            CardDate = model.CardDate,
        //            CardCvv = model.CardCvv,
        //            UserId = user.Id
        //        };
        //        _paymentDal.Insert(card);
        //        return RedirectToAction("MyAccount");
        //    }
        //    return View(model);
        //}
    }
} 