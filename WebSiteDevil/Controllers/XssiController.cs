using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebSiteDevil.Configuration;

namespace WebSiteDevil.Controllers
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
            return View();
        }

        public IActionResult JsonHijacking()
        {
            return View(webSitesSettings);
        }
        
        public IActionResult StaticJavaScript()
        {
            return View(webSitesSettings);
        }

        public IActionResult SimpleHttpRequest()
        {
            return View(webSitesSettings);
        }

    }
}