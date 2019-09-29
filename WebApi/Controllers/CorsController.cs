using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    //[EnableCors("OnlyAngel")]
    //[EnableCors("AnyOrigin")]
    //[EnableCors("AnyOriginWithoutCredentials")]
    [Route("api/[controller]")]
    [ApiController]
    public class CorsController : ControllerBase
    {        
        [HttpPost(template:nameof(SignInCookie))]        
        public ActionResult<string> SignInCookie()
        {
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

        [HttpGet(template:nameof(GetSecret))]        
        public ActionResult<string> GetSecret()
        {
            string tokenValue;
            Request.Cookies.TryGetValue("Token", out tokenValue);

            if(tokenValue == "SecretToken")
            {
                return Ok("SecretValue");
            }

            return Unauthorized("Unauthorized");
        }
    }
}
