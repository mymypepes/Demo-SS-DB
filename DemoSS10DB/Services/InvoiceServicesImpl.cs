using DemoSS10DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoSS10DB.Services
{
    public class InvoiceServicesImpl : InvoiceServices
         
    {
        private DatabaseContext db;
        public InvoiceServicesImpl(DatabaseContext _db)
        {
            db = _db;
        }
        List<Invoice> InvoiceServices.FinAll()
        {
            return db.Invoices.ToList();
        }

        List<Invoice> InvoiceServices.Search(string keyword)
        {
            return db.Invoices.Where(a => a.Name.Contains(keyword)).ToList();
        }
    }
}
