using OnlineShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace OnlineShop.Repository
{
    public interface IAccountCustomerReposistory
    {
        public bool Create(AccountCustomer accountCustomer);
        public bool Delete(string phone);
        public List<AccountCustomer> GetAll();

        public AccountCustomer findByID(string phone);

        public bool checkUsername(string username);
        public bool checkEmail(string email);

        public bool checkLogin(string username, string password);
    }
    public class AccountCustomerRepository : IAccountCustomerReposistory
    {
        private IflyShopContext _ctx;
        public AccountCustomerRepository(IflyShopContext ctx)
        {
            _ctx = ctx;
        }

        public bool Create(AccountCustomer accountCustomer)
        {
            _ctx.AccountCustomers.Add(accountCustomer);
            _ctx.SaveChanges();
            return true;
        }

        public bool Delete(string phone)
        {
            AccountCustomer c = _ctx.AccountCustomers.FirstOrDefault(x => x.Phone == phone);
            _ctx.AccountCustomers.Remove(c);
            _ctx.SaveChanges();
            return true;
        }

        public List<AccountCustomer> GetAll()
        {
            return _ctx.AccountCustomers.ToList();
        }

        public AccountCustomer findByID(string phone)
        {
            AccountCustomer c = _ctx.AccountCustomers.FirstOrDefault(x => x.Phone == phone);
            return c;
        }

        public bool checkUsername(string username)
        {
            AccountCustomer c = _ctx.AccountCustomers.Where(x => x.Username.Trim() == username.Trim()).FirstOrDefault();
            if (c == null)
                return false;
            else
                return true;
        }

        public bool checkEmail(string email)
        {
            AccountCustomer c = _ctx.AccountCustomers.Where(x => x.Email.Trim() == email.Trim()).FirstOrDefault();
            if (c == null)
                return false;
            else
                return true;
        }

        public bool checkLogin(string username, string password)
        {
            AccountCustomer c = _ctx.AccountCustomers.Where(x => x.Username.Trim() == username.Trim() && x.Password == password).FirstOrDefault();
            if (c == null)
                return false;
            else
                return true;
        }
    }
}
