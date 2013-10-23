using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Core;
using Domain;
using Lab.Filters;
using Lab.Models;

namespace Lab.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public HomeController()
        {
            Mapping.CreateMapping();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            IEnumerable<PersonInfo> persons = DataAccessLayer.GetAllPersons();
            IEnumerable<DataModel> models = Mapper.Map<IEnumerable<PersonInfo>, IEnumerable<DataModel>>(persons);
            return View("ListView", models);
        }

        [LoggingFilter]
        public ActionResult Delete(int id)
        {
            DataAccessLayer.DeletePerson(id);
            return List();
        }

        public ActionResult Details(int id)
        {
            PersonInfo person = DataAccessLayer.GetPerson(id);
            DataModel model = Mapper.Map<PersonInfo, DataModel>(person);
            return View("Info", model);
        }
        //
        // Post: /Home/
        [HttpPost]
        [LoggingFilter]
        public ActionResult Save(DataModel model)
        {
            PersonInfo person = Mapper.Map<DataModel, PersonInfo>(model);
            person = DataAccessLayer.SavePerson(person);
            model = Mapper.Map<PersonInfo, DataModel>(person);
            return View("Info",model);
        }

        public PersonInfo person { get; set; }

        public DataModel model { get; set; }
    }
}
