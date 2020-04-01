using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebSiteDevil.Configuration;

namespace WebSiteDevil.Controllers
{
    public class CsrfController : Controller
    {
        private readonly WebSitesSettings webSitesSettings;
        public CsrfController(IOptions<WebSitesSettings> webSitesSettings)
        {
            this.webSitesSettings = webSitesSettings.Value;
        }

        public IActionResult Demo01()
        {
            return View(webSitesSettings);
        }

        public IActionResult Demo02()
        {
            return View(webSitesSettings);
        }

        public IActionResult Demo03()
        {
            return View(webSitesSettings);
        }

        public IActionResult Demo04()
        {
            return View(webSitesSettings);
        }
    }
}