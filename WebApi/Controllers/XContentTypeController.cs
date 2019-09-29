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
        [HttpGet(template: nameof(MimeConfusionAttack))]
        public ActionResult<PersonDto[]> MimeConfusionAttack()
        {
            Response.Headers.Add("X-Content-Type-Options", "nosniff");

            string tokenValue;
            Request.Cookies.TryGetValue("Token", out tokenValue);

            //if (tokenValue == "SecretToken")
            {
                var restult = new PersonDto[]
                {
                    new PersonDto
                    {
                        Id = 1,
                        Name = "Secret John"
                    },
                    new PersonDto
                    {
                        Id = 2,
                        Name = "Secret William"
                    }
                };

                return Ok(restult);
            }

            return Unauthorized("Unauthorized");
        }

        public class PersonDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }    
}