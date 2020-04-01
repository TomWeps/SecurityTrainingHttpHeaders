using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSiteAngel.Models;
using WebSiteAngel.Models.Xss;

namespace WebSiteAngel.Controllers
{
    public class XssController : Controller
    {       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reflected([FromQuery] string text)
        {
            var model = new XssModel
            {
                Data = text
            };
            return View("Reflected", model);
        }

        [HttpPost]
        public IActionResult ReflectedPost(XssModel model)
        {
            return RedirectToAction("Reflected", new { text = model.Data } );
        }

        public IActionResult Stored()
        {
            var model = new XssStored
            {
                Collection = XssPersistence.Items
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult StoredPost(XssModel model)
        {
            XssPersistence.Items.Add(model);
            return View(XssPersistence.Items);
        }

        public IActionResult Dom()
        {
            return View();
        }

        public IActionResult ExampleHref()
        {
            return View();
        }

        [HttpGet]
        public IActionResult InjectionTypes()
        {
            var result = new XssInjectionsRepository().GetAll();
            return View(result);
        }

        public IActionResult InjectionType(int id)
        {
            var result = new XssInjectionsRepository().GetById(id);
            return View(result);
        }

    }
}