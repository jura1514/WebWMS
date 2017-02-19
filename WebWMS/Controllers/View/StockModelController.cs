using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebWMS.Models;

namespace WebWMS.Controllers.View
{
    public class StockModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StockModel
        public ActionResult Index()
        {
            var stockModels = db.StockModels.Include(s => s.DeliveryLineModel).Include(s => s.LocationModel).Include(s => s.ProductModel);
            return View(stockModels.ToList());
        }

        // GET: StockModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockModel stockModel = db.StockModels.Find(id);
            if (stockModel == null)
            {
                return HttpNotFound();
            }
            return View(stockModel);
        }

        // GET: StockModel/Create
        public ActionResult Create()
        {
            ViewBag.DeliveryLineId = new SelectList(db.DeliveryLineModels, "DeliveryLineId", "Name");
            ViewBag.Location = new SelectList(db.LocationModels, "LocationId", "LocationId");
            ViewBag.Product = new SelectList(db.ProductModels, "ProdId", "ProdId");
            return View();
        }

        // POST: StockModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StockId,Name,Description,DeliveryLineId,Product,Location,StockState,StateChangeTime,Qty")] StockModel stockModel)
        {
            if (ModelState.IsValid)
            {
                db.StockModels.Add(stockModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeliveryLineId = new SelectList(db.DeliveryLineModels, "DeliveryLineId", "Name", stockModel.DeliveryLineId);
            ViewBag.Location = new SelectList(db.LocationModels, "LocationId", "LocState", stockModel.Location);
            ViewBag.Product = new SelectList(db.ProductModels, "ProdId", "ProdState", stockModel.Product);
            return View(stockModel);
        }

        // GET: StockModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockModel stockModel = db.StockModels.Find(id);
            if (stockModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeliveryLineId = new SelectList(db.DeliveryLineModels, "DeliveryLineId", "Name", stockModel.DeliveryLineId);
            ViewBag.Location = new SelectList(db.LocationModels, "LocationId", "LocState", stockModel.Location);
            ViewBag.Product = new SelectList(db.ProductModels, "ProdId", "ProdState", stockModel.Product);
            return View(stockModel);
        }

        // POST: StockModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StockId,Name,Description,DeliveryLineId,Product,Location,StockState,StateChangeTime,Qty")] StockModel stockModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeliveryLineId = new SelectList(db.DeliveryLineModels, "DeliveryLineId", "Name", stockModel.DeliveryLineId);
            ViewBag.Location = new SelectList(db.LocationModels, "LocationId", "LocState", stockModel.Location);
            ViewBag.Product = new SelectList(db.ProductModels, "ProdId", "ProdState", stockModel.Product);
            return View(stockModel);
        }

        // GET: StockModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockModel stockModel = db.StockModels.Find(id);
            if (stockModel == null)
            {
                return HttpNotFound();
            }
            return View(stockModel);
        }

        // POST: StockModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockModel stockModel = db.StockModels.Find(id);
            db.StockModels.Remove(stockModel);
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
