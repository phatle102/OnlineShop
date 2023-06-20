using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace OnlineShop.Repository
{

    public interface IOrderRepository
    {
        public bool Create(Order order);
        public bool Update(Order order);
        public bool Delete(string orderId);
        
        public Order findByID(string id);
        public List<Order> GetAll();

    }
    public class OrderRepository : IOrderRepository
    {
        private IflyShopContext _ctx;
        public OrderRepository(IflyShopContext ctx)
        {
            _ctx = ctx;
        }
        public bool Create(Order order)
        {
            _ctx.Orders.Add(order);
            _ctx.SaveChanges();
            return true;
        }

        public bool Delete(string orderId)
        {
            //find id
            Order c = _ctx.Orders.FirstOrDefault(x => x.IdOrder == orderId);
            _ctx.Orders.Remove(c);
            _ctx.SaveChanges();
            return true;
        }

        public List<Order> GetAll()
        {
            return _ctx.Orders.ToList();
        }

        public bool Update(Order order)
        {
            Order c = _ctx.Orders.FirstOrDefault(x => x.IdOrder == order.IdOrder);
            if(c!=null)
            {
                _ctx.Entry(c).CurrentValues.SetValues(order);
                _ctx.SaveChanges();
            }
            return true;
        }

        public Order findByID(string id) 
        {
            Order c = _ctx.Orders.FirstOrDefault(x => x.IdOrder == id);
            return c;
        }
    }
}
