using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class RefererController : Controller
    { 
        public IActionResult Index()
        {
            string referer = Request.Headers["Referer"];
            using (var stream = new System.IO.StreamWriter(@"C:\temp\Referer", append: true))
            {
                stream.WriteLine($"{DateTime.Now} - referer: {referer}" );
                stream.Flush();
                stream.Close();
            }

            return File("images/little_devil.png", "image/png");
        }
    }
}