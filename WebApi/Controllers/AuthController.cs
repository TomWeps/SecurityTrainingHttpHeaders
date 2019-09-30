using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [DisableCors()]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        [HttpPost(template: nameof(SignInCookie))]
        public ActionResult<string> SignInCookie()
        {
            string origin = Request.Headers["origin"];
            Response.Headers.Add("Access-Control-Allow-Origin", origin);
            Response.Headers.Add("Access-Control-Allow-Credentials", "true");

            var cookieOptions = new CookieOptions
            {
                HttpOnly = false,
                Secure = false,
                Path = "/",
                IsEssential = true,
                MaxAge = TimeSpan.FromMinutes(10.0),
                SameSite = SameSiteMode.None
            };

            Response.Cookies.Append("Token", "SecretToken", cookieOptions);
            return Ok("The secret token is saved in the cookie");
        }
    }
}