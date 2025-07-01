using BusiniessLayer.Abstract;
using BusiniessLayer.Concrete;
using EntitiyLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TakiTokacim.Models;

namespace TakiTokacim.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPaymentService _paymentService;

        public PaymentsController(IUserService userService, IPaymentService paymentService)
        {
            _userService = userService;
            _paymentService = paymentService;
        }



        [Authorize]
        [HttpGet]
        public IActionResult AddCard()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddCard(AddCardViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                var card = new Payment
                {
                    PaymentName = model.PaymentName,
                    CardNumber = model.CardNumber,
                    CardDate = model.CardDate,
                    CardCvv = model.CardCvv,
                    TypeId=1,
                    UserId = _userService.GetUserId(User)
                };
                _paymentService.Insert(card);
                return RedirectToAction("MyAccount","Account");
            }
            return View(model);
        }


        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var values= _paymentService.GetById(id);
            if (values != null) { 
            
                _paymentService.Delete(values);
                TempData["DeleteMessage"] = "Kartınız başarıyla silindi.";
            }
            return RedirectToAction("MyAccount", "Account");
        }
    }
}
