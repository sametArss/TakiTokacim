using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TakiTokacim.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            // Örnek sepet (gerçek projede session veya veritabanından gelir)
            var cart = new List<dynamic>
            {
                new { Name = "Zarif Altın Yüzük", Price = 1200, Quantity = 1 },
                new { Name = "İnci Kolye", Price = 950, Quantity = 2 }
            };
            return View(cart);
        }
    }
} 