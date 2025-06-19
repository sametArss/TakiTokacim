using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TakiTokacim.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index(string category)
        {
            // Örnek ürün listesi (gerçek projede veritabanından gelir)
            var products = new List<dynamic>
            {
                new { Id = 1, Name = "Zarif Altın Yüzük", Category = "Yüzükler", Price = 1200, Image = "https://images.unsplash.com/photo-1517841905240-472988babdf9?auto=format&fit=crop&w=400&q=80" },
                new { Id = 2, Name = "İnci Kolye", Category = "Kolyeler", Price = 950, Image = "https://images.unsplash.com/photo-1464983953574-0892a716854b?auto=format&fit=crop&w=400&q=80" },
                new { Id = 3, Name = "Taşlı Bileklik", Category = "Bileklikler", Price = 700, Image = "https://images.unsplash.com/photo-1506744038136-46273834b3fb?auto=format&fit=crop&w=400&q=80" },
                new { Id = 4, Name = "Altın Küpe", Category = "Küpeler", Price = 600, Image = "https://images.unsplash.com/photo-1519125323398-675f0ddb6308?auto=format&fit=crop&w=400&q=80" }
            };
            if (!string.IsNullOrEmpty(category))
                products = products.FindAll(p => p.Category == category);
            ViewBag.SelectedCategory = category;
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var products = new List<dynamic>
            {
                new { Id = 1, Name = "Zarif Altın Yüzük", Category = "Yüzükler", Price = 1200, Image = "https://images.unsplash.com/photo-1517841905240-472988babdf9?auto=format&fit=crop&w=400&q=80", Description = "Şıklığın tamamlayıcısı, modern tasarım altın yüzük." },
                new { Id = 2, Name = "İnci Kolye", Category = "Kolyeler", Price = 950, Image = "https://images.unsplash.com/photo-1464983953574-0892a716854b?auto=format&fit=crop&w=400&q=80", Description = "Zarif ve klasik bir görünüm sunan inci kolye." },
                new { Id = 3, Name = "Taşlı Bileklik", Category = "Bileklikler", Price = 700, Image = "https://images.unsplash.com/photo-1506744038136-46273834b3fb?auto=format&fit=crop&w=400&q=80", Description = "Her stile uygun, göz alıcı detaylara sahip bileklik." },
                new { Id = 4, Name = "Altın Küpe", Category = "Küpeler", Price = 600, Image = "https://images.unsplash.com/photo-1519125323398-675f0ddb6308?auto=format&fit=crop&w=400&q=80", Description = "Zarif altın küpe ile şıklığınızı tamamlayın." }
            };
            var product = products.Find(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }
    }
} 