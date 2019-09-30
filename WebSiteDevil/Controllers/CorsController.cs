using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSiteDevil.Models;

namespace WebSiteDevil.Controllers
{
    public class CorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }      
    }
}
