using System.Web.Mvc;
using Lab1.Models;

namespace Lab1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        //
        // Post: /Home/
        [HttpPost]
        public ActionResult Save(DataModel model)
        {
            return View("Info",model);
        }
         
    }
}
