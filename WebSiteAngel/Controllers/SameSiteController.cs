using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebSiteAngel.Configuration;
using Microsoft.Extensions.Options;

namespace WebSiteAngel.Controllers
{
    public class SameSiteController : Controller
    {
        const string CookieKey = "SameSite-Auth";
        const string CookieVal = "Authenticated";

        private readonly WebSitesSettings webSitesSettings;

        public SameSiteController(IOptions<WebSitesSettings> webSitesSettings)
        {
            this.webSitesSettings = webSitesSettings.Value;
        }

        public IActionResult Index()
        {
            return View(webSitesSettings);
        }

        public IActionResult Demo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Authenticate(string samesite)
        {
            SameSiteMode sameSiteMode;
            if (Enum.TryParse(samesite, out sameSiteMode))
            {
                this.Response.Cookies.Append(
                    key: CookieKey,
                    value: CookieVal,
                    options: new Microsoft.AspNetCore.Http.CookieOptions
                    {
                        HttpOnly = false,
                        SameSite = sameSiteMode
                    });
            }
            else
            {
                this.Response.Cookies.Delete(CookieKey);
            }

            return View("Demo");
        }

        [HttpGet]
        public IActionResult HasCookieGet()
        {
            return Content(BuildContent());
        }

        [HttpPost]
        public IActionResult HasCookiePost()
        {
            return Content(BuildContent());
        }

        [HttpGet]
        [ResponseCache(Duration = 0, NoStore = true)]
        public IActionResult HasCookieImage()
        {
            string imgFile = CheckAuthentication() ? "/csrf/Authenticated.png" : "/csrf/UnAuthenticated.png";
            return File(imgFile, "image/png");
        }


        private string BuildContent()
        {
            return CheckAuthentication() ? "Authenticated" : "NOT Authenticated";
        }

        private bool CheckAuthentication()
        {
            string val;
            bool isAuthentication = Request.Cookies.TryGetValue(CookieKey, out val) && val == CookieVal;
            ViewBag.isAuthenticated = isAuthentication;
            return isAuthentication;
        }
    }
}