using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TakiTokacim.Models;
using Microsoft.AspNetCore.Authorization;
using BusiniessLayer.Abstract;
using EntitiyLayer.Models;

namespace TakiTokacim.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IAboutService _aboutService;
    private readonly IContactService _contactService;

    public HomeController(ILogger<HomeController> logger, IAboutService aboutService, IContactService contactService)
    {
        _logger = logger;
        _aboutService = aboutService;
        _contactService = contactService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult About()
    {
        var about = _aboutService.GetByAbout(1); // varsayılan tek About kaydı
        return View(about);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public IActionResult UpdateAboutMessage([FromBody] string message)
    {
        var about = _aboutService.GetByAbout(1);
        if (about == null)
            return Json(new { success = false, error = "Kayıt bulunamadı." });
        about.AboutMessage = message;
        _aboutService.Update(about);
        TempData["AboutInfo"] = "Hakkımızda Sayfası Güncellendi";
        return Json(new { success = true });
    }

    public IActionResult Contact()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Contact(EntitiyLayer.Models.Contact contact)
    {
        if (ModelState.IsValid)
        {
            _contactService.Insert(contact);
            
            TempData["ContactInfo"] = "Mesajınız başarıyla gönderildi!";
            return RedirectToAction("Contact");
        }
        TempData["ContactInfo"] = "Lütfen tüm alanları doldurun.";
        return View(contact);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
