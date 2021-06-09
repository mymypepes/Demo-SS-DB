using System;
using System.Collections.Generic;

#nullable disable

namespace DemoSS10DB.Models
{
    public partial class Invoice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Total { get; set; }
        public string Payment { get; set; }
        public string Status { get; set; }
    }
}
