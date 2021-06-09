using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using DemoSS10DB.Services;

namespace DemoSS10DB.Controllers
{
    [Route("demo")]
    public class DemoController : Controller
    {
        
        private IConfiguration configuration;
        private CalulationService calulationService;
        public DemoController (IConfiguration _configuration, CalulationService _calulationService)
        {
            calulationService = _calulationService;
            configuration = _configuration;
        }
        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            string myconfig1 = configuration["myconfig1"].ToString();
            Debug.WriteLine("myconfig1" + myconfig1);
            string config2 = configuration["myconfig2:config2"];
            Debug.WriteLine("config2" + config2);
            string config3 = configuration["myconfig2:config3:config3_1"];
            Debug.WriteLine("config3" + config3);

            return View();
        }
        [Route("index2")]
        public IActionResult Index2()
        {
            double result1 = calulationService.Add(1, 2);
            Debug.WriteLine("result" + result1);
            double result2 = calulationService.Mul(5, 4);
            Debug.WriteLine("result" + result2);
            return View("index");
        }
    }
}
