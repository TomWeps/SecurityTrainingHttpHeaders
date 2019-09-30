using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebSiteAngel.Controllers
{
    public class CorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Demo()
        {
            return View();
        }
    }
}