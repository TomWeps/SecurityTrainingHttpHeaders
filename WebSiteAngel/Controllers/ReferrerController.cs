using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebSiteAngel.Controllers
{
    public class ReferrerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DefaultReferrerPolicy()
        {
            ViewData["Referrer"] = "Default (not set explicitly)";
            return View("Demo");
        }

        public IActionResult NoReferrerPolicy()
        {
            ViewData["Referrer"] = "no-referrer";
            Response.Headers.Add("Referrer-Policy", "no-referrer");
            return View("Demo");
        }

       
    }
}