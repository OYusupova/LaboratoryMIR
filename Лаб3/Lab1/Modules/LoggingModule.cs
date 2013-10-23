using System;
using System.IO;
using System.Web;
using Lab.Log;

namespace Lab.Modules
{
    public class LoggingModule: IHttpModule
    {
        private readonly LogManager _logManager;

        public LoggingModule()
        {
            _logManager = new LogManager();
        }

        public void Init(HttpApplication context)
        {
            context.LogRequest += LogRequest;
        }

        private void LogRequest(object sender, EventArgs e)
        {
            var request = string.Join("/", HttpContext.Current.Request.RequestContext.RouteData.Values);
            var logData = String.Format("Request: {0}", request);
            _logManager.SaveLog(LogType.RequestLog, logData);
        }

        public void Dispose()
        {
        }
    }
}