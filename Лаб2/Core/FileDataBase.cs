using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core
{
    public class FileDataBase<T>
    {
        private readonly string _path;
        private string FileName { get { return typeof (T).Name+".txt"; } }
        public FileDataBase()
        {
            this._path = System.Configuration.ConfigurationManager.AppSettings["FileDataBase"];
            if (_path.StartsWith("~"))
            {
                string path = Path.GetFullPath(Assembly.GetAssembly(typeof(FileDataBase<T>)).CodeBase);
                _path = _path.Replace("~", path);
            }
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
        }

        public IEnumerable<T> GetAllEntity()
        {
            var sr = new StreamReader(_path + FileName, true);
            var str = sr.ReadToEnd();
            var m =Regex.Matches(str, "<.>");
            foreach (var match in m)
            {
                
            }
            return new List<T>();
        }

        public void Save(T entity)
        {
            var sw = new StreamWriter(_path + FileName, true);
            var pr = entity.GetType().GetProperties();
            var str = string.Join(";", pr.Select(x => string.Format("{0}:{1}", x.Name, x.GetValue(entity, null))));
            sw.WriteLine("<{0}>", str);
            sw.Close();
        }
    }
}
