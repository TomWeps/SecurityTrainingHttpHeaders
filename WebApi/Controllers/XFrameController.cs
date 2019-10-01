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
    [EnableCors("OnlyAngel")]
    [Route("api/[controller]")]
    [ApiController]
    public class XFrameController : ControllerBase
    {
        [HttpPost(template: nameof(ExecuteSecretCommand))]
        public ActionResult<string> ExecuteSecretCommand()
        {
            if (AuthHelper.IsAuthenticated(Request))
            {
                return Ok("Secret Command was executed");
            }

            return Unauthorized("Unauthorized");
        }
    }
}