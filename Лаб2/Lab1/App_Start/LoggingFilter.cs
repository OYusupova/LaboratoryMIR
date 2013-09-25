using System;
using System.Web.Mvc;
using System.IO;

namespace Lab.App_Start
{
    public class LoggingFilterAttribute : ActionFilterAttribute
    {
        private string _logFileName = System.Configuration.ConfigurationManager.AppSettings["LogFileName"];
        private string _logDirectory = System.Configuration.ConfigurationManager.AppSettings["LogDirectory"];
        private string _logPath;
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var ip = filterContext.HttpContext.Request.UserHostAddress;
            var action = filterContext.ActionDescriptor.ActionName;
            string data;
            if (filterContext.Exception != null)
                data = "Exception: " + filterContext.Exception.Message;
            else
            {
                data = ((ViewResult)filterContext.Result).Model.ToString();
            }
            _logPath = filterContext.HttpContext.Server.MapPath("~/" + _logDirectory + "/");
            SaveLog(ip,action,data);
            base.OnActionExecuted(filterContext);
        }

        private void SaveLog(string ip, string action, string data)
        {
            if (!Directory.Exists(_logPath))
            {
                Directory.CreateDirectory(_logPath);
            }
            var message = string.Format("{0};{1};{2};{3}", DateTime.Now, ip, action, data);

            var sw = new StreamWriter(_logPath + _logFileName, true);
            sw.WriteLine(message);
            sw.Close();
        }
    }
}