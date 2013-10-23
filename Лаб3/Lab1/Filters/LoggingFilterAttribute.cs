using System;
using System.IO;
using System.Web.Mvc;
using Lab.Log;

namespace Lab.Filters
{
    public class LoggingFilterAttribute : ActionFilterAttribute
    {

        private readonly LogManager _logManager;

        public LoggingFilterAttribute()
        {
            _logManager = new LogManager();
        }

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
            
            SaveLog(ip,action,data);
            base.OnActionExecuted(filterContext);
        }

        private void SaveLog(string ip, string action, string data)
        {
            var message = string.Format("{0};{1};{2}", ip, action, data);
            _logManager.SaveLog(LogType.ActionLog, message);
        }
    }
}