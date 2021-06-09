using DemoSS10DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoSS10DB.Services
{
    public class AccountServicesImpl : AccountServices
    {
        private DatabaseContext db;
        public AccountServicesImpl(DatabaseContext _db)
        {
            db = _db;
        }

        public Account Create(Account account)
        {
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }

        public void Delete(int id)
        {
            db.Accounts.Remove(db.Accounts.Find(id));
            db.SaveChanges();
        }

        public List<Account> FinAll()
        {
            return db.Accounts.ToList();
        }

        public Account Find(int id)
        {
            return db.Accounts.Find(id);
        }

        public List<Account> Search(string keyword)
        {
            return db.Accounts.Where(a => a.FullName.Contains(keyword)).ToList();
        }

        public void Update(Account account)
        {
            db.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
