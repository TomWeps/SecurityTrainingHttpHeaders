using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XFrameController : ControllerBase
    {
        [HttpPost(template: nameof(ExecuteSecretCommand))]
        public ActionResult<string> ExecuteSecretCommand()
        {
            string tokenValue;
            Request.Cookies.TryGetValue("Token", out tokenValue);

            if (tokenValue == "SecretToken")
            {
                return Ok("Secret Command was executed");
            }

            return Unauthorized("Unauthorized");
        }
    }
}