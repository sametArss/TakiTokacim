using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EntitiyLayer.Models;
using TakiTokacim.Models;
using Microsoft.AspNetCore.Authorization;
using DataAcsessLayer.Abstract;
using BusiniessLayer.Abstract;
using Azure.Core;

namespace TakiTokacim.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAdressService _adressService;
        private readonly IPaymentService _paymentService;
        private readonly IContactService _contactService;
        private readonly IUserService _userService; 


        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IAdressService adressService , IPaymentService paymentService, IContactService contactService, IUserService userService)
        {
            _adressService =adressService;
            _userManager = userManager;
            _signInManager = signInManager;
            _paymentService = paymentService;
            _contactService = contactService;
            _userService = userService;
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
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || !user.UserStatus)
                {
                    ModelState.AddModelError("", "Hesabınız kapatılmıştır veya bulunamadı.");
                    return View(model);
                }

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
            TempData["LogoutInfo"] = "Başarıyla çıkış yaptınız.";
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

        [Authorize(Roles = "Admin")]
        public IActionResult Messages()
        {
            var messages = _contactService.GetAllMessage();
            ViewBag.UnreadCount = messages.Count(x => !x.IsRead);
            return View(messages);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MarkAsRead(int id)
        {
            var msg = _contactService.GetByIdContact(id);
            if (msg != null && !msg.IsRead)
            {
                msg.IsRead = true;
                _contactService.Update(msg);
            }
            return Json(new { success = true });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteMessage(int id)
        {
            var msg = _contactService.GetByIdContact(id);
            if (msg != null)
            {
                _contactService.Delete(msg);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAccount()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                await _signInManager.SignOutAsync();
                _userService.Delete(user);
                TempData["DeleteMessage"] = "Hesabınız başarıyla kapatıldı.";
                return RedirectToAction("Index", "Home");
            }
            TempData["DeleteMessage"] = "Bir hata oluştu, lütfen tekrar deneyin.";
            return RedirectToAction("MyAccount");
        }
       

   
    }
} 