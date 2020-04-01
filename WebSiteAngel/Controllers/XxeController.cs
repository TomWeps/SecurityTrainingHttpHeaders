using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using WebSiteAngel.Models;

namespace WebSiteAngel.Controllers
{
    public class XxeController : Controller
    {
        private readonly string XmlRelativePath = @"xxe";
        private readonly string XmlFileNameOK = "test.xml";
        private readonly string XmlFileNameHack = "testHack.xml";

        private readonly IHostingEnvironment hostEnv;

        public XxeController(IHostingEnvironment hostEnv)
        {
            this.hostEnv = hostEnv;
        }

        public IActionResult Index()
        {            
            return View();
        }

        public IActionResult DemoNormal()
        {                  
            return View("Result",Parse(XmlFileNameOK));
        }

        public IActionResult DemoHack()
        {
            
            return View("Result", Parse(XmlFileNameHack));
        }

        private XxeResultModel Parse(string xmlFileName)
        {
            string xmlFilePath = Path.Combine(hostEnv.WebRootPath, XmlRelativePath, xmlFileName);

            return new XxeResultModel
            {
                XmlDocument = ParseWithXmlDocument(xmlFilePath),
                XmlReader = ParseWithXmlReader(xmlFilePath)
            };
        }        

        private string ParseWithXmlDocument(string xmlFilePath)
        {
            XmlUrlResolver resolver = new XmlUrlResolver();
            resolver.Credentials = CredentialCache.DefaultCredentials;

            var xml = new XmlDocument();
            xml.XmlResolver = resolver; // 4.6 >=  is defaulted to Null,  4.5 and erlier is danger
            xml.Load(xmlFilePath);

            string result = xml.DocumentElement.InnerText;
            return result;
        }

        private string ParseWithXmlReader(string xmlFilePath)
        {
            XmlUrlResolver resolver = new XmlUrlResolver();
            resolver.Credentials = CredentialCache.DefaultCredentials;

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;  // .net 4.0+ Parse (Default) 
            settings.XmlResolver = resolver;


            string result = string.Empty;
            using (var stream = new StreamReader(xmlFilePath))
            {
                using (XmlReader reader = XmlReader.Create(stream, settings))
                {
                    while (reader.Read())
                    {
                        result += reader.Value;
                        result += Environment.NewLine;
                    }
                }
            }

            return result;            
        }
    }
}