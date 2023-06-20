using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class ProductDAO
    {
        private IflyShopContext _ctx;

        public ProductDAO()
        {
            _ctx = new IflyShopContext();

        }
        public List<Product> getAllProduct()
        {
            //select * from Products
            return _ctx.Products.ToList();
        }

        public Boolean CreateProduct(Product product)
        {
            _ctx.Products.Add(product);
            _ctx.SaveChanges();
            return true;
        }
        public Boolean UpdateProduct(Product updateProduct)
        {

            //1 findByID
            Product product = _ctx.Products.Where(x => x.IdProduct == updateProduct.IdProduct).SingleOrDefault();
            //3.update
            _ctx.Products.Update(product);
            _ctx.SaveChanges();
            return true;
        }
        public Boolean DeleteProduct(String IdProduct)
        {
            //1 findByID
            Product product = _ctx.Products.Where(x => x.IdProduct == IdProduct).SingleOrDefault();
            _ctx.Products.Remove(product);
            _ctx.SaveChanges();
            return true;
        }
    }
}
