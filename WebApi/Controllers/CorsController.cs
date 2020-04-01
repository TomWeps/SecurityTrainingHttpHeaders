using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Utilities;

namespace WebApi.Controllers
{
    [DisableCors()]    
    [Route("api/[controller]")]
    [ApiController]
    public class CorsController : ControllerBase
    {
        /*
        [HttpOptions(template: nameof(GetSecretOptions))]
        public ActionResult<string> GetSecretOptions()
        {
            return Ok("");
        }
        */

        [HttpPost(template:nameof(WithoutCors))]        
        public ActionResult<string> WithoutCors()
        {
            return Ok("SecretValue - WithoutCors");            
        }

        [HttpPost(template: nameof(AllowOriginWildCard))]
        public ActionResult<string> AllowOriginWildCard()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return Ok("SecretValue - AllowOriginWildCard");
        }

        [HttpPost(template: nameof(AllowOriginWildCardAndCredentials))]
        public ActionResult<string> AllowOriginWildCardAndCredentials()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Credentials", "true");

            if (AuthHelper.IsAuthenticated(Request))
            {
                return Ok("SecretValue - AllowOriginWildCard");
            }

            return Unauthorized("Unauthorized");
        }

        [HttpPost(template: nameof(AllowCredentials))]
        public ActionResult<string> AllowCredentials()
        {
            string origin = Request.Headers["origin"];
            Response.Headers.Add("Access-Control-Allow-Origin", origin);
            Response.Headers.Add("Access-Control-Allow-Credentials", "true");

            if (AuthHelper.IsAuthenticated(Request))
            {
                return Ok("SecretValue - AllowCredentials");
            }

            return Unauthorized("Unauthorized");            
        }

        [HttpPost(template: nameof(AllowAngelsOnly))]
        public ActionResult<string> AllowAngelsOnly()
        {
            string origin = Request.Headers["origin"];
            Response.Headers.Add("Access-Control-Allow-Origin", "http://angel.local");
            Response.Headers.Add("Access-Control-Allow-Credentials", "true");

            if (AuthHelper.IsAuthenticated(Request))
            {
                return Ok("SecretValue - AllowAngelsOnly");
            }

            return Unauthorized("Unauthorized");
        }


    }
}

 
