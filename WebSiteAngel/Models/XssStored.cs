using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteAngel.Models
{
    public class XssStored
    {
        public IEnumerable<XssModel> Collection { get; set; }
        public XssModel New { get; set; }
    }
}
