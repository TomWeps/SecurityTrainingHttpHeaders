using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteAngel.Models
{
    public static class XssPersistence
    {
        public static List<XssModel> Items { get; private set; }

        static XssPersistence()
        {
            Items = new List<XssModel>()
            {
                new XssModel { Data = "One" },
                new XssModel { Data = "Two" },
                new XssModel { Data = "Three" }
            };
        }
    }
}
