using BusiniessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TakiTokacim.Controllers
{
    public class TestController : Controller
    {

        private readonly ICategoryService _categoryService;

        public TestController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var values =_categoryService.GetAll();
            return View(values);
        }


        public IActionResult Index2()
        {
            
            return View();
        }
    }
}
