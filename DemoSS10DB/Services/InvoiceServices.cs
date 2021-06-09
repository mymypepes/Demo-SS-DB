using DemoSS10DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoSS10DB.Services
{
    public interface InvoiceServices
    {
        public List<Invoice> FinAll();
        public List<Invoice> Search(string keyword);
    }
}
