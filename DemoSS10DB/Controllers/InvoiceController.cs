using DemoSS10DB.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoSS10DB.Controllers
{
    [Route("invoice")]
    public class InvoiceController : Controller
    {
        private InvoiceServices invoiceServices;
        private IWebHostEnvironment webHostEnviroment;
        public InvoiceController(InvoiceServices _invoiceServices, IWebHostEnvironment _webHostEnviroment)
        {
            invoiceServices = _invoiceServices;
            webHostEnviroment = _webHostEnviroment;
        }


        [Route("index")]
        [Route("")]
        [Route("~/")]
        public IActionResult Index()
        {
            ViewBag.invoices = invoiceServices.FinAll();
            return View();
        }

        [Route("search")]
        public IActionResult Search([FromQuery(Name = "keyword")] string keyword)
        {
            ViewBag.invoices = invoiceServices.Search(keyword);
            return View("Index");
        }
    }
}
