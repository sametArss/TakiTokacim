using BusiniessLayer.Abstract;
using EntitiyLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TakiTokacim.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        
        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }


        public IActionResult Index(string category)
        {
            var products = string.IsNullOrEmpty(category)
                ? _productService.GetAllProducts()
                : _productService.GetByCategory(category);

            var categories = _categoryService.GetAllCategory();
            ViewBag.Categories = categories;
            ViewBag.SelectedCategory = category;

            return View(products);
        }

        public  IActionResult Details(int id)
        {
            var product = _productService.GetByIdProduct(id);
            if (product == null) return NotFound();        

            return View(product);
        }
    }
} 