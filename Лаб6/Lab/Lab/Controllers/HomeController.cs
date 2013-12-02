using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.UI;

namespace Lab.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToRoute("Login");
        }

        [OutputCache(Duration = 60, VaryByParam = "*", Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult LongOperation()
        {
            Thread.Sleep(5000);
            ViewBag.Operation = "Долгая операция( OutputCache )";
            if (Request.IsAjaxRequest())
            {
                return PartialView("LongOperation");
            }

            return View("LongOperation");
        }

        public ActionResult LongOperation2()
        {
            ActionResult result = null;
            result = CacheGet(Request.Path);
            if (result != null)
            {
                return result;
            }

            Thread.Sleep(5000);
            if (Request.IsAjaxRequest())
            {
                result = PartialView("LongOperation");
            }
            else
            {
                result = View("LongOperation");
            }
            ViewBag.Operation = "Долгая операция( Cache )";
            CacheAdd(Request.Path,result);
            return result;
        }

        /// <summary>
        /// Положить результат в кэш
        /// </summary>
        /// <param name="actionName"></param>
        /// <param name="actionResult"></param>
        public void CacheAdd(string actionName, ActionResult actionResult)
        {
            if (HttpContext.Cache[actionName] == null)
            {
                HttpContext.Cache.Add(actionName, actionResult, null, DateTime.Now.AddSeconds(60), Cache.NoSlidingExpiration,
                    CacheItemPriority.High, null);
            }
        }

        /// <summary>
        /// Забрать рузультат из кэша
        /// </summary>
        /// <param name="actionName"></param>
        /// <returns></returns>
        public ActionResult CacheGet(string actionName)
        {
            var qq = HttpContext.Cache.Get(actionName);
            return (ActionResult)qq;
        }

    }
}
