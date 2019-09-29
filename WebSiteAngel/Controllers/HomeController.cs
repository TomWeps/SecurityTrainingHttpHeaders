using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSiteAngel.Models;

namespace WebSiteAngel.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {            
            return View();
        }

        public IActionResult XFrameOptions()
        {
            Response.Headers.Add("X-Frame-Options", "deny");
            return View();
        }

        public IActionResult XSSProtection(string user)
        {            
            //Response.Headers.Add"X-XSS-Protection", "0");
            Response.Headers.Add("X-XSS-Protection", "1; mode=block");

            ViewData["user"] = user;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
