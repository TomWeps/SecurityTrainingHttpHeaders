using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebSiteAngel.Controllers
{
    public class XssController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult XSSProtectionOff(string user)
        {
            Response.Headers.Add("X-XSS-Protection", "0");
            return Demo(user);
        }

        public IActionResult XSSProtectionOn(string user)
        {            
            Response.Headers.Add("X-XSS-Protection", "1; mode=block");
            return Demo(user);
        }

        private IActionResult Demo(string user)
        {
            ViewData["user"] = user;

            return View("Demo");
        }
    }
}