using DemoSS10DB.Models;
using DemoSS10DB.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DemoSS10DB.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private AccountServices accountServices;
        private IWebHostEnvironment webHostEnviroment;
        public AccountController(AccountServices _accountServices, IWebHostEnvironment _webHostEnviroment)
        {
            accountServices = _accountServices;
            webHostEnviroment = _webHostEnviroment;
        }
        [Route("index")]
        //[Route("")]
        //[Route("~/")]
        public IActionResult Index()
        {
            ViewBag.accounts = accountServices.FinAll();
            return View();
        }

        [Route("search")]
        public IActionResult Search([FromQuery(Name = "keyword")] string keyword)
        {
            ViewBag.accounts = accountServices.Search(keyword);
            return View("Index");
        }

        [Route("details/{id}")]
        public IActionResult Details(int id)
        {
            ViewBag.account = accountServices.Find(id);
            return View("Details");
        }
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var account = accountServices.Find(id);
            return View("edit", account);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, Account account, IFormFile file)
        {
            var craccount = accountServices.Find(id);
            if (!string.IsNullOrEmpty(account.Password))
            {
                craccount.Password = BCrypt.Net.BCrypt.HashString(account.Password);
            }
            if (file != null)
            {
                var fileName = System.Guid.NewGuid().ToString().Replace("-", "");
                var ext = file.ContentType.Split(new char[] { '/' })[1];
                var path = Path.Combine(webHostEnviroment.WebRootPath, "images", fileName + "." + ext);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                craccount.Photo = fileName + "." + ext;
            }
            craccount.Username = account.Username;
            craccount.FullName = account.FullName;
            accountServices.Update(craccount);
            return RedirectToAction("index");
        }
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            accountServices.Delete(id);
            return RedirectToAction("index"); // chuyen ham index cho no load lai
            //return View(""); van dung trong dg link 
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {

            return View("Add", new Account());
        }
        [HttpPost]
        [Route("add")]
        public IActionResult Add(Account account, IFormFile file)
        {
            if (file != null)
            {

                var fileName = System.Guid.NewGuid().ToString().Replace("-", "");

                var ext = file.ContentType.Split(new char[] { '/' })[1];

                var path = Path.Combine(webHostEnviroment.WebRootPath, "images", fileName + "." + ext);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                account.Photo = fileName + "." + ext;
            }
            else
            {
                account.Photo = "hinhdo.png";
            }
            account.Password = BCrypt.Net.BCrypt.HashString(account.Password);
            accountServices.Create(account);
            return RedirectToAction("index");
        }
    }
}
