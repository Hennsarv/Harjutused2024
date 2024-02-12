using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EsimeneVeeb.Models;

namespace EsimeneVeeb.Controllers
{
    public class InimeneController : MyController
    {
        // GET: Inimene
        public ActionResult Index()
        {
            var list = Inimene.Rahvas.Values.ToList();
            return View(list);
        }

        // GET: Inimene/Details/5
        public ActionResult Details(int id)
        {
            Inimene inimene = Inimene.Rahvas.TryGetValue(id, out var i)
                ? i : null
                ;
            if (inimene == null) return RedirectToAction("Index");

            return View(inimene);
        }

        // GET: Inimene/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inimene/Create
        [HttpPost]
        public ActionResult Create(Inimene inimene)
        {
            try
            {
                inimene.id = Inimene.Rahvas.Keys.Max() + 1;
                Inimene.Rahvas.Add(inimene.id, inimene);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View(inimene);
            }
        }

        // GET: Inimene/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Inimene inimene = Inimene.Rahvas.TryGetValue(id, out var i)
            ? i : null;
            if (inimene == null) return RedirectToAction("Index");

            return View(inimene);
        }

        // POST: Inimene/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Inimene inimene)
        {
            try
            {
                // TODO: Add update logic here
                Inimene eelmine = Inimene.Rahvas[id];
                eelmine.Nimi = inimene.Nimi;
                eelmine.Vanus = inimene.Vanus;



                return RedirectToAction("Index");
            }
            catch
            {
                return View(inimene);
            }
        }

        // GET: Inimene/Delete/5
        public ActionResult Delete(int id)
        {
            Inimene inimene = Inimene.Rahvas.TryGetValue(id, out var i)
            ? i : null
            ;
            if (inimene == null) return RedirectToAction("Index");
            return View(inimene);
        }

        // POST: Inimene/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Inimene inimene)
        {
            try
            {
                // TODO: Add delete logic here
                Inimene.Rahvas.Remove(id);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
