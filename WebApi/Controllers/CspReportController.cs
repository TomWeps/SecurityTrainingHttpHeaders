using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CspReportController : ControllerBase
    {
        [HttpPost()]
        public ActionResult<string> Collect()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = reader.ReadToEnd();

                Console.Out.WriteLine(body);
            }
            return Ok();
        }
    }
}