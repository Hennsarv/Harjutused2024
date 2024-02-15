using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsimeneVeeb.Controllers
{
    public class HomeController : MyController
    {
        public ActionResult Index()
        {
            // järgmised kaks rida on samaväärsed
            ViewBag.Test1 = ParamsBag.Test;
            ViewData["Test2"] = Request.Params["Test"];
            TempBag.Test = "testime sega";
            return View();
        }

        public ActionResult About(string nimi = "", int id = 0)
        {
            ViewBag.Message = "Meie rakenduse kirjeldus.";
            ViewBag.Mina = "Henn";
            ViewBag.Nimi = nimi;
            ViewBag.Id = id; 
            ViewData["Mumm"] = "Mumm";


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}