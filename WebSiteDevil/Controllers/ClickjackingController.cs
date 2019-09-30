using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebSiteDevil.Controllers
{
    public class ClickjackingController : Controller
    {
        public IActionResult Index(string dstUri)
        {
            ViewData["IFrameDst"] = dstUri;

            return View();
        }
    }
}