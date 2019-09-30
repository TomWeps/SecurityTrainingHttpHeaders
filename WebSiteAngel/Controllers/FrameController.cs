using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebSiteAngel.Controllers
{
    public class FrameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult XFrameOptionsNoDeny()
        {
            return Demo();
        }

        public IActionResult XFrameOptionsDeny()
        {
            Response.Headers.Add("X-Frame-Options", "deny");
            return Demo();
        }

        private IActionResult Demo()
        {
            return View("Demo");
        }
    }
}