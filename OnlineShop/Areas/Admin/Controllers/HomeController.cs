﻿using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.Repository;
using Microsoft.AspNetCore.Authorization;
using OnlineShop.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;    
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public HomeController(IProductRepository productRepository, ICategoryRepository categoryRepository, SignInManager<ApplicationUser> signInManager, ILogger<HomeController> logger)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _signInManager = signInManager;
            _logger = logger;
        }
        public IActionResult Index()
        {
            List<Product> lstProduct = _productRepository.GetAllProduct();
            return View(lstProduct);
        }

        [HttpPost]
        public IActionResult SaveCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                bool isCategoryNameExist = _categoryRepository.checkName(category.CategoryName);

                if (isCategoryNameExist)
                {
                    ModelState.AddModelError(string.Empty, "CategoryName is Exist !!!");
                    return View("CreateCategory");
                }
                else
                {
                    _categoryRepository.Create(category);
                    return RedirectToAction("ViewAllCategories");
                }
            }
            else
            {
                return View("CreateCategory");
            }
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View("CreateCategory", new Category());
        }

        public IActionResult DeleteCategory(string id)
        {
            _categoryRepository.Delete(id);
            return RedirectToAction("ViewAllCategories");
        }

        public IActionResult EditCategory(string id)
        {
            var q1 = from c in _categoryRepository.GetAllCategories()
                     select new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                     {
                         Text = c.CategoryName,
                         Value = c.CategoryId
                     };
            ViewBag.CategoryId = q1.ToList();
            return View("EditCategory", _categoryRepository.findByID(id));
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryRepository.Update(category);
            return RedirectToAction("ViewAllCategories");
        }

        [HttpPost]
        public IActionResult SaveProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                bool isProductNameExist = _productRepository.checkName(product.ProductName);

                if (isProductNameExist)
                {
                    ModelState.AddModelError(string.Empty, "ProductName is Exist !!!");
                    return View("CreateProduct");
                }
                else
                {
                    _productRepository.Create(product);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View("CreateProduct");
            }
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            var q1 = from c in _productRepository.GetAllProduct()
                     select new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                     {
                         Text = c.ProductName,
                         Value = c.IdProduct
                     };

            ViewBag.IdProduct = q1.ToList();
           //ViewBag.CCategoryId = q2.ToList();
            return View("CreateProduct", new Product());
        }

        public IActionResult EditProduct(string id)
        {
            var q1 = from c in _productRepository.GetAllProduct()
                     select new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                     {
                         Text = c.ProductName,
                         Value = c.IdProduct
                     };
            ViewBag.IdProduct = q1.ToList();
            return View("EditProduct", _productRepository.findByID(id));
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _productRepository.Update(product);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(string id)
        {
            _productRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult ViewAllCategories()
        {
            List<Category> lst = _categoryRepository.GetAllCategories();
            return View("ViewAllCategories", lst);
        }

        public IActionResult ViewAllProducts()
        {
            List<Product> lst = _productRepository.GetAllProduct();
            return View("Index", lst);
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return LocalRedirect("/home/index");
        }
    }
}