using NewsEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsEngine.Controllers
{
    public class ExamplesController : Controller
    {
        //
        // GET: /Page/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RazorExample()
        {
            return View();
        }

        public ViewResult GetExample(int x, int y) //Передача через именные параметры
        {
            ViewBag.xxx = x;
            ViewBag.yyy = y;
            return View();
        }

        public ViewResult GetExamplePerson(string PersonName, int PersonAge, string PersonPlace)
        {
            ViewBag.PersonName = PersonName;
            ViewBag.PersonAge = PersonAge;
            ViewBag.PersonPlace = PersonPlace;
            return View();
        }

        public ViewResult GetExamplePersonObject(Person Person) //Person создается в вызове функции
        {
            ViewBag.Person = Person;
            return View();
        }

        public ViewResult GetExampleForTypizedView(Person Person)
        {
            return View(Person);
        }

        [HttpGet] //атрибут по умолчанию, можно не писать
        public ViewResult PostFormExample()
        {
            return View();
        }

        [HttpPost] //атрибут писать обязательно, иначе не заработает
        public ActionResult PostFormExample(string text, int i)
        {
            bool error = false;
            ViewBag.text = text;
            ViewBag.i = i;

            if(error)
                return View();

            TempData["text"] = text;
            TempData["i"] = i;

            return RedirectToAction("PostFormExampleResult");
        }
        public ViewResult PostFormExampleResult()
        {
            return View();
        }

        public ActionResult PostFormCollectionExample()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostFormCollectionExample(FormCollection FormCollection)
        {
            bool error = false;
            //ViewBag.text = text;
            //ViewBag.i = i;

            if (error)
                return View();

            TempData["text"] = FormCollection["text"];
            TempData["i"] = FormCollection["i"];

            return RedirectToAction("PostFormCollectionExampleResult");
        }

        public ViewResult PostFormCollectionExampleResult()
        {
            return View();
        }


        ////////////////////////////////////////////////////
        ////////////////////////////////////////////////////
        ////////////////////////////////////////////////////
        [HttpGet]
        public ViewResult AjaxFormExample()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AjaxFormExample(string text, int i)
        {
            ViewBag.text = text;
            ViewBag.i = i;
            //return PartialView();
            return PartialView("_AjaxFormExampleResult");
        }
	}
}