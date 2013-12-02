using System;
using System.IO;
using System.Web;
using Lab.Log;

namespace Lab.Modules
{
    public class LoggingModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.LogRequest += LogRequest;
        }

        private void LogRequest(object sender, EventArgs e)
        {
            var request = HttpContext.Current.Request.Path + " " + string.Join(", ", HttpContext.Current.Request.QueryString);
            var logData = String.Format("Request: {0}", request);
            LogManager.SaveLog(LogType.RequestLog, logData);
        }

        public void Dispose()
        {
        }
    }
}

