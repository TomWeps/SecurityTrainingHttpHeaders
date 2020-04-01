using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteAngel.Models.Xss
{
    public class XssInjection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  HtmlBefore { get; set; }
        public string HtmlAfter { get; set; }
        public string Injection { get; set; }
        public string Defense { get; set; }
    }
}
