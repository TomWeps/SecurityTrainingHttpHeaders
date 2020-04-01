using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using WebSiteAngel.Configuration;
using Microsoft.Extensions.Options;

namespace WebSiteAngel.Controllers
{
    public class SsrfController : Controller
    {
        private readonly WebSitesSettings webSitesSettings;

        public SsrfController(IOptions<WebSitesSettings> webSitesSettings)
        {
            this.webSitesSettings = webSitesSettings.Value;
        }

        public IActionResult Index()
        {
            return View("Index", webSitesSettings.AngelUri);
        }

        [HttpGet]
        public async Task<IActionResult> GetResource(string file)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(file);
            string fileContent = await response.Content.ReadAsStringAsync();

            return Content(fileContent);
        }
    }
}