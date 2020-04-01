using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebSiteAngel.Configuration;

namespace WebSiteAngel.Controllers
{
    public class XssiController : Controller
    {
        private readonly WebSitesSettings webSitesSettings;

        public XssiController(IOptions<WebSitesSettings> webSitesSettings)
        {
            this.webSitesSettings = webSitesSettings.Value;
        }

        public IActionResult Index()
        {
            return View(webSitesSettings);
        }

        public IActionResult DemoJsonArray()
        {
            var dataArray = new[]
            {
                new SomeData()
                {
                    Name = "John",
                    Secret = "John's Secret"
                },
                new SomeData()
                {
                    Name = "Peter",
                    Secret = "Peter's Secret"
                }
            };

            return Json(dataArray);
        }

        private class SomeData
        {
            public string Name { get; set; }
            public string Secret { get; set; }

        }
    }
}