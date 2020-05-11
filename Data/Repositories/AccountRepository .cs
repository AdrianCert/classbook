using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using System.Data.Entity;
using Data.Entities;


namespace Data.Repositories 
{
    public class AccountRepository
    {
        private Context.AccountContext _context = null;
        private DbSet<UserAccount> table = null;
        public AccountRepository()
        {
            this._context = new Context.AccountContext();
            table = _context.Set<UserAccount>();
        }
        public IEnumerable<UserAccount> GetAll()
        {
            return table.ToList();
        }
        public UserAccount GetById(Guid id)
        {
            return table.Find(id);
        }

        public UserAccount GetByMail(string mail)
        {
            var acList = _context.Accounts.ToList();
            return _context.Accounts.FirstOrDefault(a => a.Email == mail);
        }
        public void Insert(UserAccount obj)
        {
            table.Add(obj);
        }
        public void Update(UserAccount obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            UserAccount existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
            _context.Dispose();
        }
    }
}
