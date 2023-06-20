using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace OnlineShop.Repository
{

    public interface ICustomerRepository
    {
        public bool Create(Customer customer);
        public bool Update(Customer customer);
        public bool Delete(string customerId);
        
        public bool checkName(string name);
        public Customer findByID(string id);
        public List<Customer> GetAll();

    }
    public class CustomerRepository : ICustomerRepository
    {
        private IflyShopContext _ctx;
        public CustomerRepository(IflyShopContext ctx)
        {
            _ctx = ctx;
        }
        public bool Create(Customer customer)
        {
            _ctx.Customers.Add(customer);
            _ctx.SaveChanges();
            return true;
        }

        public bool Delete(string customerId)
        {
            //find id
            Customer c = _ctx.Customers.FirstOrDefault(x => x.IdCustomer == customerId);
            _ctx.Customers.Remove(c);
            _ctx.SaveChanges();
            return true;
        }

        public List<Customer> GetAll()
        {
            return _ctx.Customers.ToList();
        }

        public bool Update(Customer customer)
        {
            Customer c = _ctx.Customers.FirstOrDefault(x => x.IdCustomer == customer.IdCustomer);
            if(c!=null)
            {
                _ctx.Entry(c).CurrentValues.SetValues(customer);
                _ctx.SaveChanges();
            }
            return true;
        }

        public Customer findByID(string id) 
        {
            Customer c = _ctx.Customers.FirstOrDefault(x => x.IdCustomer == id);
            return c;
        }

        public bool checkName(string name)
        {
            Customer c = _ctx.Customers.Where(x => x.NameCustomer.Trim() == name.Trim()).FirstOrDefault();
            if (c == null)
            {
                return false;
            }
            else return true;
        }
        
    }
}
