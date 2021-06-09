using System;
using System.Collections.Generic;

#nullable disable

namespace DemoSS10DB.Models
{
    public partial class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Photo { get; set; }
    }
}
