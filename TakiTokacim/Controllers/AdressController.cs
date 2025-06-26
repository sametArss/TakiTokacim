using BusiniessLayer.Abstract;
using DataAcsessLayer.Abstract;
using EntitiyLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TakiTokacim.Models;

namespace TakiTokacim.Controllers
{
    public class AdressController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IDistrictService _districtService;
        private  readonly IUserService _userService;
        private  readonly IAdressService _adressService;

        public AdressController(ICityService cityService, IDistrictService districtService, IUserService userService, IAdressService adressService)
        {
            _cityService = cityService;
            _districtService = districtService;
            _userService = userService;
            _adressService = adressService;
            
        }



        [HttpGet]
        public JsonResult GetDistrictsByCity(int cityId)
        {
            // DistrictService veya context ile ilgili ilçeleri çekin
            var districts = _districtService.GetDistricts(cityId)
                .Select(d => new { d.DistrictId, d.DistrictName }).ToList();
            return Json(districts);
        }


        [Authorize]
        [HttpGet]
        public IActionResult AddAdress()
        {
            ViewBag.Cities = _cityService.GetAll();
            ViewBag.Districts = new List<District>();
          
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddAdress(AddAdressViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var adress = new UserAdress
                {
                    AdressTitle = model.AdressTitle,
                    AdressDescription = model.AdressDescription,
                    CityId = model.CityId,
                    DistrictId = model.DistrictId,
                    UserId = _userService.GetUserId(User)
                };
                _adressService.Insert(adress);
                return RedirectToAction("MyAccount","Account");
            }
            ViewBag.Cities = _cityService.GetAll();
            ViewBag.Districts = new List<District>();
            return View(model);
        }


       
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Cities = _cityService.GetAll();
            ViewBag.Districts = new List<District>();
            var value = _adressService.GetById(id); 
            return View(value);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(UserAdress model)
        {
            var userId = _userService.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
            {
                ModelState.AddModelError("UserId", "Kullanıcı oturum açmamış.");
            }
            model.UserId = userId;

            // UserId formdan gelmediği için oluşan validasyon hatasını temizle
            ModelState.Remove("UserId");

            if (ModelState.IsValid)
            {
                _adressService.Update(model);   
                return RedirectToAction("MyAccount", "Account");
            }
            ViewBag.Cities = _cityService.GetAll();
            ViewBag.Districts = _districtService.GetDistricts(model.CityId);
            return View(model);
        }


        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var values = _adressService.GetById(id);
            if (values != null)
            {
                _adressService.Delete(values);
                TempData["DeleteMessage"] = "Adres başarıyla silindi.";
            }
            return RedirectToAction("MyAccount", "Account");
        }

    }

}

