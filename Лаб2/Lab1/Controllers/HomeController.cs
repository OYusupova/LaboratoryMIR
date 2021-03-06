﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Core;
using Domain;
using Lab.App_Start;
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
            var persons = DataAccessLayer.GetAllPersons();
            var models = Mapper.Map<IEnumerable<PersonInfo>, IEnumerable<DataModel>>(persons);
            return View("ListView", models);
        }

        public ActionResult Details(int id)
        {
            var person = DataAccessLayer.GetPerson(id);
            var model = Mapper.Map<PersonInfo, DataModel>(person);
            return View("Info", model);
        }
        //
        // Post: /Home/
        [HttpPost]
        [LoggingFilter]
        public ActionResult Save(DataModel model)
        {
            var person = Mapper.Map<DataModel, PersonInfo>(model);
            person = DataAccessLayer.Save(person);
            model = Mapper.Map<PersonInfo, DataModel>(person);
            return View("Info",model);
        }


         
    }
}
