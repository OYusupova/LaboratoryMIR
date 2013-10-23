using System;
using System.IO;
using System.Web;

namespace Lab.Log
{
    public class LogManager
    {
        public void SaveLog(LogType type, string logData)
        {
            var logFileName = System.Configuration.ConfigurationManager.AppSettings[type.ToString()];
            var logDirectory = System.Configuration.ConfigurationManager.AppSettings["LogDirectory"];
            var logPath = HttpContext.Current.Server.MapPath("~/" + logDirectory + "/");
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
            var message = string.Format("{0};{1}", DateTime.Now, logData);

            var sw = new StreamWriter(logPath + logFileName, true);
            sw.WriteLine(message);
            sw.Close();
        } 
    }
}