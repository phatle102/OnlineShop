using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;
using OnlineShop.Repository;
using System.Diagnostics;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IProductRepository _productRepository;
        private ProductDAO productDAO = new ProductDAO();
        IflyShopContext db = new IflyShopContext();

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            List<Product> products = _productRepository.GetAllProduct();
            return View(products);
        }


        public IActionResult Product()
        {
            return View("Product");
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


        public IActionResult ProductDetail(string Idproduct)
        {
            var product = db.Products.SingleOrDefault(x => x.IdProduct == Idproduct);
            return View(product);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}