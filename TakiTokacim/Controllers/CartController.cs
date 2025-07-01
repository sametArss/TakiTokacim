using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TakiTokacim.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
           
            return View();
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