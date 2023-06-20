using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace OnlineShop.Repository
{

    public interface ICategoryRepository
    {
        public bool Create(Category category);
        public bool Update(Category category);
        public bool Delete(string categoryId);

        public bool checkName(string name);
        public Category findByID(string id);
        public List<Category> GetAllCategories();

    }
    public class CategoryRepository : ICategoryRepository
    {
        private IflyShopContext _ctx;
        public CategoryRepository(IflyShopContext ctx)
        {
            _ctx = ctx;
        }
        public bool Create(Category category)
        {
            _ctx.Categories.Add(category);
            _ctx.SaveChanges();
            return true;
        }

        public bool Delete(string categoryId)
        {
            //find id
            Category c = _ctx.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
            _ctx.Categories.Remove(c);
            _ctx.SaveChanges();
            return true;
        }

        public List<Category> GetAllCategories()
        {
            return _ctx.Categories.ToList();
        }

        public bool Update(Category category)
        {
            Category c = _ctx.Categories.FirstOrDefault(x => x.CategoryId == category.CategoryId);
            if (c != null)
            {
                _ctx.Entry(c).CurrentValues.SetValues(category);
                _ctx.SaveChanges();
            }
            return true;
        }

        public Category findByID(string id)
        {
            Category c = _ctx.Categories.FirstOrDefault(x => x.CategoryId == id);
            return c;
        }

        public bool checkName(string name)
        {
            Category c = _ctx.Categories.Where(x => x.CategoryName.Trim() == name.Trim()).FirstOrDefault();
            if (c == null)
            {
                return false;
            }
            else return true;
        }

    }
}
