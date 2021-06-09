using DemoSS10DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoSS10DB.Services
{
    public interface AccountServices
    {
        public List<Account> FinAll();
        public List<Account> Search(string keyword);
        public Account Find(int id);
        public Account Create(Account account);
        public void Delete(int id);
        public void Update(Account account);
    }
}
