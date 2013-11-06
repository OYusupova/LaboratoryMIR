using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.IO;
using System.Web.Routing;
using Lab.ConfigSections;

namespace Lab.Modules
{
    public class ErrorModule:IHttpModule
    {
        private static readonly ErrorModuleConfigSection ErrorModuleConfigSection = (ErrorModuleConfigSection)ConfigurationManager.GetSection("errorModuleConfig");

        public void Init(HttpApplication context)
        {
            context.BeginRequest += BeginRequest;
        }

        private void BeginRequest(object sender, EventArgs e)
        {
            var keys = GetKeys();

            var application = (HttpApplication) sender;
            var context = application.Context;
            if (keys.Any(x=>context.Request.FilePath.Contains(x)))
            {
                context.Response.RedirectToRoute("Error", new { Message = ErrorModuleConfigSection.Message.Value });
            }
        }

        private static IEnumerable<string> GetKeys()
        {
            var keys = ErrorModuleConfigSection.Keys.OfType<Key>().Select(x => x.Value);
            return keys;
        }

        public void Dispose()
        {
        }
    }
}