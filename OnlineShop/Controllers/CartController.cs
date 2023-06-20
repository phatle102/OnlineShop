
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.Repository;
namespace OnlineShop.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository _productRepository;

        public CartController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
    

        public IActionResult Cart()
        {
            ViewBag.sessionId = HttpContext.Session.Id;
            CartModel cartModel = new CartModel();
            if (HttpContext.Session.Get<List<Item>>("cart") != null)
            {
                List<Item>? items = HttpContext.Session.Get<List<Item>>("cart");
                cartModel.setAllItems(items);
            }
            return View(cartModel);
          
        }


        [HttpPost]
        public IActionResult UpdateQuantity()
        {
            var btn = Request.Form["btnUpdateQuantity"].ToString();
            var id = Request.Form["item.Id"].ToString();
            var qty = Request.Form["item.Quantity"].ToString();
            CartModel cartModel = null;
            if (HttpContext.Session.Get<List<Item>>("cart") != null)
            {
                //1
                cartModel = new CartModel();
                cartModel.CartId = HttpContext.Session.Id;

                cartModel.setAllItems(HttpContext.Session.Get<List<Item>>("cart"));
            }
            cartModel.UpdateQuantity(id, 1, btn);
            HttpContext.Session.Set<List<Item>>("cart", cartModel.getAllItems());

            return RedirectToAction("Cart");
        }

        public IActionResult addToCart(string id)
        {
            
            //fine product by id
            Product product = _productRepository.findByID(id);
            int quantity = 1;
            CartModel cartModel = null;
            if (HttpContext.Session.Get<List<Item>>("cart") != null)
            {
                //1
                cartModel = new CartModel();
                cartModel.CartId = HttpContext.Session.Id;
                cartModel.setAllItems(HttpContext.Session.Get<List<Item>>("cart"));
                //2
                Item item = new Item()
                {
                    Id = product.IdProduct,
                    Name = product.ProductName,
                    Price = (decimal)product.Cost,
                    ImagePath = product.ImgProduct,
                    Quantity = quantity,
                    lineTotal = (decimal)(quantity * product.Cost)
                };
                //3
                cartModel.addItem(item);
                //4 save session
                HttpContext.Session.Set<List<Item>>("cart", cartModel.getAllItems());
            }
            else
            {
                //the first
                cartModel = new CartModel();
                cartModel.CartId = HttpContext.Session.Id;

                Item item = new Item()
                {
                    Id = product.IdProduct,
                    Name = product.ProductName,
                    Price = (decimal)product.Cost,
                    ImagePath = product.ImgProduct,
                    Quantity = quantity,
                    lineTotal = (decimal)(quantity * product.Cost)
                };
                //3
                cartModel.addItem(item);
                //4
                HttpContext.Session.Set<List<Item>>("cart", cartModel.getAllItems());
            }


            //code here */
            return RedirectToAction("Cart");
        }
    }
}
