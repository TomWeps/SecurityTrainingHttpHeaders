using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteAngel.Models.Xss
{
    public class XssInjectionsRepository
    {
        private XssInjection[] xssInjections;

        public XssInjectionsRepository()
        {
            xssInjections = new[]
            {
              new XssInjection()
              {
                  Id = 1,
                  Name =  "Tag Content Injection",
                  HtmlBefore = "<div>",
                  HtmlAfter = "</div>",
                  Injection = "<img src onerror=alert(1)>",
                  Defense = "Characters Encoding"
              },
              new XssInjection()
              {
                  Id = 2,
                  Name =  "Attribute Content Injection - I",
                  HtmlBefore = "<div class=\"",
                  HtmlAfter = "\">Some Content</div>",
                  Injection = "\" onmouseover=alert(1) ",
                  Defense = "Characters Encoding"
              },
              new XssInjection()
              {
                  Id = 3,
                  Name =  "Attribute Content Injection - II",
                  HtmlBefore = "<div class=\"",
                  HtmlAfter = "\">Some Content</div>",
                  Injection = "\"><script>alert(1)</script>",
                  Defense = "Characters Encoding"
              },
              new XssInjection()
              {
                  Id = 4,
                  Name =  "Attribute Content Injection without quotes",
                  HtmlBefore = "<div class=",
                  HtmlAfter = " >Some Content</div>",
                  Injection = "x onclick=alert(1)",
                  Defense = "For generated html, it is better always to use attribute value in the quotas"
              },
              new XssInjection()
              {
                  Id = 5,
                  Name =  "Href Attribute Injection",
                  HtmlBefore = "<a href=\"",
                  HtmlAfter = "\">Link</a>",
                  Injection = "javascript:alert(1)",
                  Defense = "Validate if it used HTTP or HTTPS protocol"
              },
              new XssInjection()
              {
                  Id = 6,
                  Name =  "Injection into js code",
                  HtmlBefore = "<script> var username=\"",
                  HtmlAfter = "\";</script>",
                  Injection = "\"; alert(1) //",
                  Defense = "Encoding of all non-alphanumeric characters to UTF-16"
              },
              new XssInjection()
              {
                  Id = 7,
                  Name =  "Injection into attribute with js code",
                  HtmlBefore = "<div onclick=\"someFuntcion('",
                  HtmlAfter = "')\">User</div>",
                  Injection = "&#39;);alert(1)//",
                  Defense = "Proper Encoding"
              },
              new XssInjection()
              {
                  Id = 8,
                  Name =  "Injection into HREF Attribute, js protocol",
                  HtmlBefore = "<a href=\"javascript:someFuntcion('",
                  HtmlAfter = "')\"Click</a>",
                  Injection = "%27);alert(1)//",
                  Defense = "Proper Encoding"
              },
            };
        }

        public IEnumerable<XssInjection> GetAll()
        {
            return xssInjections;
        }

        public XssInjection GetById(int id)
        {
            return xssInjections.First(x => x.Id == id);
        }

    }
}
