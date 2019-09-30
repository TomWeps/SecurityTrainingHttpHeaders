using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebSiteAngel.Controllers
{
    public class HstsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Demo()
        {
            Response.Headers.Add("Strict-Transport-Security", "max-age=180;");
                       
            ViewData["IsHttps"] = Request.IsHttps;
            return View();
        }

        public IActionResult Redirect()
        {
            Response.Headers.Add("Strict-Transport-Security", "max-age=180;");
            return RedirectPermanent("https://angel.local/Hsts/Demo");
        }
    }
}