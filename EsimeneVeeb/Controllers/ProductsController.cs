using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
//using System.Web.Http;
using System.Web.Mvc;
using EsimeneVeeb.Models;
using Newtonsoft.Json;

namespace EsimeneVeeb.Controllers
{
    public class ProductsController : MyController
    {

        public ActionResult Kustomaarid()
        {
            return Json(db.Customers, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Kustomaarid2()
        {
            return Json(db.Customers
                
                .Select(x => new {x.CompanyName,x.Country})
                , JsonRequestBehavior.AllowGet);
        }



        // GET: Products
        public ActionResult Index(string sort = "PI")
        {
            var products = db.Products.Where(x => x.ProductID == x.ProductID) ;//.Include(p => p.Category);
            ViewBag.Sort = sort;
            products =
                sort == "PI" ? products.OrderBy(x => x.ProductID)
              : sort == "PN" ? products.OrderBy(x => x.ProductName)
              : sort == "UP" ? products.OrderBy(x => x.UnitPrice)
              : sort == "PID" ? products.OrderByDescending(x => x.ProductID)
              : sort == "PND" ? products.OrderByDescending(x => x.ProductName)
              : sort == "UPD" ? products.OrderByDescending(x => x.UnitPrice)
              : products;
            return View(products.ToList());
        }
        [HttpGet]
        //public JsonResult LaeAndmed()
        //{
        //    return Json(db.Products
        //        .Select(p => new { p.ProductID, p.ProductName, p.UnitPrice, p.Category.CategoryName })
        //        .ToList(), JsonRequestBehavior.AllowGet);
        //}
        public ActionResult LaeAndmed()
        {
            var products = db.Products
                .Select(p => new { p.ProductID, p.ProductName, p.UnitPrice, p.Category.CategoryName })
                .ToList();

            var jsonSettings = new JsonSerializerSettings
            {
                StringEscapeHandling = StringEscapeHandling.Default
            };

            var json = JsonConvert.SerializeObject(products, Formatting.None, jsonSettings);

            return Content(json, "application/json");
        }

        public ActionResult Demo()
        {
            return View();
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("Index");
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued,State")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued,State")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
