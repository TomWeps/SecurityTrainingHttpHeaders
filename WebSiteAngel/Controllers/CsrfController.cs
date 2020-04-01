using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using WebSiteAngel.Configuration;
using WebSiteAngel.Models;

namespace WebSiteAngel.Controllers
{
    public class CsrfController : Controller
    {
        const string CookieKey = "CSRF-Auth";
        const string CookieVal = "Authenticated";
        private readonly WebSitesSettings webSitesSettings;

        public CsrfController(IOptions<WebSitesSettings> webSitesSettings)
        {
            this.webSitesSettings = webSitesSettings.Value;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(webSitesSettings);
        }

        [HttpGet]
        public IActionResult Demo()
        {
            var model = new CsrfModel
            {
                IsAuthenticated = CheckAuthentication()
            };

            return View(model);
        }

        [HttpGet("/Csrf/Demo/SomeDangerOperationGet", Name = "SomeDangerOperation")]
        [ResponseCache(Duration = 0, NoStore = true)]
        public IActionResult SomeDangerOperation()
        {
            Request.Headers.TryGetValue("Accept", out StringValues acceptHeader);
            bool isJson = acceptHeader.Contains("application/json");            

            if(isJson)
            {
                var model = new CsrfModel
                {
                    IsAuthenticated = CheckAuthentication()
                };

                return Json(model);
            }

            string imgFile = CheckAuthentication() ? "/csrf/Authenticated.png" : "/csrf/UnAuthenticated.png";
            return File(imgFile, "image/png");
        }


        [HttpGet]
        public IActionResult DemoForm()
        {
            CheckAuthentication();
            return View();
        }


        [HttpPost("Csrf/Demo/SomeDangerOperationPost", Name = "SomeDangerOperationPost")]
        public IActionResult SomeDangerOperationPost(CsrfForm model)
        {
            CheckAuthentication();
            return View("DemoFormResult", model);
        }

        public IActionResult DemoPreventionToken()
        {
            CheckAuthentication();
            return View();
        }

        [HttpPost("Csrf/Demo/SomeDangerOperationPostPrevention", Name = "SomeDangerOperationPostPrevention")]
        [ValidateAntiForgeryToken]
        public IActionResult SomeDangerOperationPostPrevention(CsrfForm model)
        {
            CheckAuthentication();
            return View("DemoFormResult", model);
        }        

        [HttpGet]
        public IActionResult Authenticate()
        {
            this.Response.Cookies.Append(
                key: CookieKey,
                value: CookieVal,
                options: new Microsoft.AspNetCore.Http.CookieOptions
                {
                    SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None,
                    HttpOnly = true
                });
            return RedirectToAction("Demo");
        }

        [HttpGet]
        public IActionResult UnAthenticate()
        {
            this.Response.Cookies.Append(
                key: CookieKey,
                value: "-",
                options: new Microsoft.AspNetCore.Http.CookieOptions
                {
                    HttpOnly = true
                });

            return RedirectToAction("Demo");
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