using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebSiteAngel.Controllers
{
    public class CspController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult On()
        {
            const string contentPolicy = "default-src 'none'; " +
                "style-src angel.local; " +
                "script-src angel.local;";

            Response.Headers.Add("Content-Security-Policy", contentPolicy);

            return GenerateView("CSP is ON");
        }

        public IActionResult Off()
        {
            return GenerateView("CSP is Off (not set)");
        }

        private IActionResult GenerateView(string title)
        {
            ViewData["Title"] = "CSP";
            return View("Demo");
        }
    }
}