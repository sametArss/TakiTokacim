using BusiniessLayer.Abstract;
using EntitiyLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace TakiTokacim.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;
        
        public ProductsController(IProductService productService, ICategoryService categoryService,ICommentService commentService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _commentService = commentService;
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

        [Authorize]
        public IActionResult Details(int id)
        {
            var product = _productService.GetByIdProduct(id);
            if (product == null) return NotFound();

            var comments = _commentService.CommentAll(id);
            ViewBag.Comments = comments;

            return View(product);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = _categoryService.GetAllCategory();
            return View();
        }

        // Ürün Ekle (POST)
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Insert(product);
                TempData["Success"] = "Ürün başarıyla eklendi.";
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _categoryService.GetAllCategory();
            return View(product);
        }

        // Ürün Düzenle (GET)
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productService.GetByIdProduct(id);
            if (product == null) return NotFound();
            ViewBag.Categories = _categoryService.GetAllCategory();
            return View(product);
        }

        // Ürün Düzenle (POST)
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                TempData["Success"] = "Ürün başarıyla güncellendi.";
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _categoryService.GetAllCategory();
            return View(product);
        }

        // Ürün Sil (GET)
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetByIdProduct(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // Ürün Sil (POST)
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _productService.Delete(id);
            TempData["Success"] = "Ürün başarıyla silindi.";
            return RedirectToAction("Index");
        }
    } 
} 