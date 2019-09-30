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
    public class XContentTypeController : ControllerBase
    {
        [HttpGet(template: nameof(Sniff))]
        public IActionResult Sniff()
        {
            return Picture();
        }

        [HttpGet(template: nameof(NoSniff))]
        public IActionResult NoSniff()
        {
            Response.Headers.Add("X-Content-Type-Options", "nosniff");
            return Picture();
        }

        [HttpGet(template: nameof(Mime))]
        public IActionResult Mime()
        {
            Response.Headers.Add("Content-Type", "text/plain");
            //Response.Headers.Add("X-Content-Type-Options", "nosniff");
            return Picture();
        }

        private IActionResult Picture()
        {
            string fileContent = "alert(\"you've been hacked\");";
            return Ok(fileContent);
        }
    }    
}