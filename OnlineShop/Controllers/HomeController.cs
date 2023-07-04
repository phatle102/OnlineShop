using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;
using OnlineShop.Repository;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using OnlineShop.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace OnlineShop.Controllers
{

    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IProductRepository _productRepository;
        private ProductDAO productDAO = new ProductDAO();
        IflyShopContext db = new IflyShopContext();
        private readonly SignInManager<ApplicationUser> _signInManager;
        
        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository, SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _productRepository = productRepository;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 8; // Kích thước trang

            List<Product> lst = _productRepository.GetAllProduct();

            var pagedData = lst.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalItems = lst.Count;

            return View(pagedData.ToList());
        }


        public IActionResult Product()
        {
            List<Product> lst = _productRepository.GetAllProduct();
            return View(lst);
        }

        public IActionResult Blog()
        {
            return View("Blog");
        }

        public IActionResult Contact()
        {
            return View("Contact");
        }

        public IActionResult About()
        {
            return View("About");
        }

        [AllowAnonymous]
        public IActionResult ProductDetail(string Idproduct)
        {
            var product = db.Products.SingleOrDefault(x => x.IdProduct == Idproduct);
            return View(product);

        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return LocalRedirect("/home/index");
        }

       


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}