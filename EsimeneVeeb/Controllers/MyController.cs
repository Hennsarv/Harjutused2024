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
    }
}