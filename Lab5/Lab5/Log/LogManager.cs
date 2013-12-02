using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Lab.Log
{
    public static class LogManager
    {
        static readonly string LogPath = HttpContext.Current.Server
            .MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["LogDirectory"] + "/");
        static Queue<Task> SaveTask = new Queue<Task>();
        private static bool _isWorked = false;
        public static void SaveLog(LogType type, string logData)
        {
            var logFileName = System.Configuration.ConfigurationManager.AppSettings[type.ToString()];
            if (!Directory.Exists(LogPath))
            {
                Directory.CreateDirectory(LogPath);
            }
            var message = string.Format("{0};{1}", DateTime.Now, logData);
            SaveTask.Enqueue(new Task(()=>SaveMessage(message,logFileName)));
            if (_isWorked == false)
            {
                Task.Run(() => RunTask());
            }
        }

        private static void SaveMessage(string message, string logFileName)
        {
            while (true)
            {
                try
                {
                    var sw = new StreamWriter(LogPath + logFileName, true);
                    sw.WriteLine(message);
                    sw.Close();
                    return;
                }
                catch (IOException ioEx)
                {
                    Thread.Sleep(10);
                } 
            }

        }

        private static void RunTask()
        {
            _isWorked = true;
            while (SaveTask.Count>0)
            {
                var task = SaveTask.Dequeue();
                if (task != null)
                {
                    if (task.Status != TaskStatus.Running && task.Status != TaskStatus.RanToCompletion)
                    {
                        task.Start();
                    }
                }
            }
            _isWorked = false;
        }
    }
}