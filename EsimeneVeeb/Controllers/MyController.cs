using EsimeneVeeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsimeneVeeb.Controllers
{
    public class MyController : Controller
    {


        private NorthwindEntities _db = null; //new NorthwindEntities("x");

        protected NorthwindEntities db => 
            _db ?? 
            (_db = new NorthwindEntities("x"));

        dynamic _tempBag;
        protected dynamic TempBag =>
            _tempBag ?? (_tempBag = new Bag(TempData));

        dynamic _paramsBag;
        protected dynamic ParamsBag =>
            _paramsBag ?? (_paramsBag = new Bag(Request.Params));


    }
}