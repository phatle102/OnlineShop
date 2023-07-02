﻿
using Microsoft.AspNetCore.Authorization;
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

        public IActionResult Checkout()
        {
            return View("Checkout");
        }

        [AllowAnonymous]
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

            //find product by id
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
                    Description = product.ProductInformation,
                    Price = (decimal)product.Cost,
                    ImagePath = product.ImgProduct,
                    Quantity = quantity,
                    lineTotal = (decimal)(quantity * product.Cost),
                    totalMoney = (decimal)(quantity * product.Cost)
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
                    Description = product.ProductInformation,
                    Price = (decimal)product.Cost,
                    ImagePath = product.ImgProduct,
                    Quantity = quantity,
                    lineTotal = (decimal)(quantity * product.Cost),
                    totalMoney = (decimal)(quantity * product.Cost)
                };
                //3
                cartModel.addItem(item);
                //4
                HttpContext.Session.Set<List<Item>>("cart", cartModel.getAllItems());
            }


            //code here */
            return RedirectToAction("Cart");
        }

        public IActionResult removeFromCart(string id)
        {
            //find product by id
            int quantity = 1;
            Product product = _productRepository.findByID(id);
            CartModel cartModel = null;
            if (HttpContext.Session.Get<List<Item>>("cart") != null)
            {
                cartModel = new CartModel();
                cartModel.CartId = HttpContext.Session.Id;
                cartModel.setAllItems(HttpContext.Session.Get<List<Item>>("cart"));

                Item item = cartModel.getAllItems().SingleOrDefault(x => x.Id == id);
                item = new Item();
               
                if (item != null)
                {
                    cartModel.removeItem(item);
                    HttpContext.Session.Set<List<Item>>("cart", cartModel.getAllItems());
                }
            }

            return RedirectToAction("Cart");
        }

        
        /*public IActionResult ViewAllProducts(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 1; // Kích thước trang

            List<Product> lst = _productRepository.GetAllProduct();

            var pagedData = lst.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalItems = lst.Count;

            return View(pagedData.ToList());
        }*/
    }


    


}

