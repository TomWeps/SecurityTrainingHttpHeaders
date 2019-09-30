﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebSiteAngel.Controllers
{
    public class ContentTypeController : Controller
    {
        const string apiBaseUri = "https://localhost:5001/api/XContentType/";

        public IActionResult Example1()
        {
            ViewData["Title"] = "1: sniff";
            ViewData["ScriptSrc"] = $"{apiBaseUri}sniff";

            return View("Index");
        }

        public IActionResult Example2()
        {
            ViewData["Title"] = "2: NO sniff";
            ViewData["ScriptSrc"] = $"{apiBaseUri}NoSniff";

            return View("Index");
        }

        public IActionResult Example3()
        {
            ViewData["Title"] = "2: MimeType";
            ViewData["ScriptSrc"] = $"{apiBaseUri}Mime";

            return View("Index");
        }
    }
}