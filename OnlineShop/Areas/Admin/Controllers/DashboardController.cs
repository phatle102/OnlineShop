﻿using Microsoft.AspNetCore.Mvc;
using OnlineShop.Repository;
using OnlineShop.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class DashboardController : Controller
    {
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;

        public DashboardController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
   

            _productRepository = productRepository;
            _categoryRepository = categoryRepository;

        }
        public IActionResult Index()
        {
            //1
            List<Product> lstProduct = _productRepository.GetAllProduct();

            //2
            return View(lstProduct);

        }

    }
}
