using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebSiteDevil.Configuration;

namespace WebSiteDevil.Controllers
{
    public class SameSiteController : Controller
    {
        private readonly WebSitesSettings webSitesSettings;
        public SameSiteController(IOptions<WebSitesSettings> webSitesSettings)
        {
            this.webSitesSettings = webSitesSettings.Value;
        }

        public IActionResult Index()
        {
            return View(webSitesSettings);
        }
    }
}