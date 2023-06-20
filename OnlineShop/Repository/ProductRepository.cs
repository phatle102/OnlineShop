using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

using OnlineShop.Models;

namespace OnlineShop.Repository
{

    public interface IProductRepository
    {
        public bool Create(Product product);
        public bool Update(Product product);
        public bool Delete(string productId);

        public Product findByID(string id);
        public List<Product> GetAllProduct();
        public List<Product> GetAllProductsByCategoryId(string id);
        bool checkName(string? productName);

    }
    public class ProductRepository : IProductRepository
    {
        private IflyShopContext _ctx;
        public ProductRepository(IflyShopContext ctx)
        {
            _ctx = ctx;
        }
        public bool Create(Product product)
        {
            _ctx.Products.Add(product);
            _ctx.SaveChanges();
            return true;
        }

        public bool Delete(string productId)
        {
            //find id
            Product c = _ctx.Products.FirstOrDefault(x => x.IdProduct == productId);
            _ctx.Products.Remove(c);
            _ctx.SaveChanges();
            return true;
        }

        public List<Product> GetAllProduct()
        {
            return _ctx.Products.ToList();
        }

        public bool Update(Product product)
        {
            Product c = _ctx.Products.FirstOrDefault(x => x.IdProduct == product.IdProduct);
            if (c != null)
            {
                _ctx.Entry(c).CurrentValues.SetValues(product);
                _ctx.SaveChanges();
            }
            return true;
        }

        public Product findByID(string id)
        {
            Product c = _ctx.Products.FirstOrDefault(x => x.IdProduct == id);
            return c;
        }



        public bool checkName(string name)
        {
            Product c = _ctx.Products.Where(x => x.ProductName.Trim() == name.Trim()).FirstOrDefault();
            if (c == null)
            {
                return false;
            }
            else return true;
        }



        public List<Product> GetAllProductsByCategoryId(string id)
        {
            return _ctx.Products.Where(x => x.IdProduct == id).ToList();
        }
    }
}
