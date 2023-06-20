using Microsoft.AspNetCore.Mvc;
using OnlineShop.Repository;
using OnlineShop.Models;
namespace OnlineShop.Controllers
{
    public class AccountController : Controller
    {
        private IAccountCustomerReposistory _accountcustomerReposistory;
        private IflyShopContext _ctx;
        public AccountController(IAccountCustomerReposistory accountcustomerReposistory, IflyShopContext ctx)
        {
            _accountcustomerReposistory = accountcustomerReposistory;
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

    }
}
