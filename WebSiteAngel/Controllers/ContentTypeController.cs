using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebSiteAngel.Controllers
{
    public class ContentTypeController : Controller
    {
        const string apiBaseUri = "https://localhost:5001/api/XContentType/";

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Example1()
        {
            ViewData["Title"] = "1: sniff";
            ViewData["ScriptSrc"] = $"{apiBaseUri}sniff";
            ViewData["ResponseHeaders"] = "Content-Type: text/plain;";

            return View("Demo");
        }

        public IActionResult Example2()
        {
            ViewData["Title"] = "2: NO sniff";
            ViewData["ScriptSrc"] = $"{apiBaseUri}NoSniff";
            ViewData["ResponseHeaders"] = "Content-Type: text/plain;  + X-Content-Type-Options: nosniff";

            return View("Demo");
        }

        public IActionResult Example3()
        {
            ViewData["Title"] = "2: MimeType";
            ViewData["ScriptSrc"] = $"{apiBaseUri}Mime";

            return View("Demo");
        }
    }
}