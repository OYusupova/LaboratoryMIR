using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Threading;
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
            return View("ListView");
        }

        [HttpPost]
        public ActionResult GetPersonsForListView()
        {
            IEnumerable<PersonInfo> persons = DataAccessLayer.GetAllPersons();
            IEnumerable<DataModel> models = Mapper.Map<IEnumerable<PersonInfo>, IEnumerable<DataModel>>(persons);
            return Json(models.Select(x => new
            {
                x.Id,
                x.FirstName,
                x.MiddleName,
                x.SurName
            }));
        }

        [HttpPost]
        [LoggingFilter]
        public ActionResult Delete(int id)
        {
            Thread.Sleep(5000);//Задержка добавлена для нагляности(чтоб шарики могли покружится:))
            DataAccessLayer.DeletePerson(id);
            return GetPersonsForListView();
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

        public ActionResult ShowError(string message)
        {
           
            ViewBag.Error = message;
            return View("Error");
        }
    }
}
