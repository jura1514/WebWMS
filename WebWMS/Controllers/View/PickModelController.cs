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
    public class PickModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PickModel
        public ActionResult Index()
        {
            var pickModels = db.PickModels.Include(p => p.DeliveryLineModel).Include(p => p.OrderModel).Include(p => p.ProductModel);
            return View(pickModels.ToList());
        }

        // GET: PickModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickModel pickModel = db.PickModels.Find(id);
            if (pickModel == null)
            {
                return HttpNotFound();
            }
            return View(pickModel);
        }

        // GET: PickModel/Create
        public ActionResult Create()
        {
            ViewBag.DeliveryLineId = new SelectList(db.DeliveryLineModels, "DeliveryLineId", "Name");
            ViewBag.OrderId = new SelectList(db.OrderModels, "OrderId", "OrderState");
            ViewBag.Product = new SelectList(db.ProductModels, "ProdId", "ProdState");
            return View();
        }

        // POST: PickModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PickId,OrderId,DeliveryLineId,Product,PickState,StateChangeTime,Description,ActualQty,PlannedQty")] PickModel pickModel)
        {
            if (ModelState.IsValid)
            {
                db.PickModels.Add(pickModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeliveryLineId = new SelectList(db.DeliveryLineModels, "DeliveryLineId", "Name", pickModel.DeliveryLineId);
            ViewBag.OrderId = new SelectList(db.OrderModels, "OrderId", "OrderState", pickModel.OrderId);
            ViewBag.Product = new SelectList(db.ProductModels, "ProdId", "ProdState", pickModel.Product);
            return View(pickModel);
        }

        // GET: PickModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickModel pickModel = db.PickModels.Find(id);
            if (pickModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeliveryLineId = new SelectList(db.DeliveryLineModels, "DeliveryLineId", "Name", pickModel.DeliveryLineId);
            ViewBag.OrderId = new SelectList(db.OrderModels, "OrderId", "OrderState", pickModel.OrderId);
            ViewBag.Product = new SelectList(db.ProductModels, "ProdId", "ProdState", pickModel.Product);
            return View(pickModel);
        }

        // POST: PickModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PickId,OrderId,DeliveryLineId,Product,PickState,StateChangeTime,Description,ActualQty,PlannedQty")] PickModel pickModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pickModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeliveryLineId = new SelectList(db.DeliveryLineModels, "DeliveryLineId", "Name", pickModel.DeliveryLineId);
            ViewBag.OrderId = new SelectList(db.OrderModels, "OrderId", "OrderState", pickModel.OrderId);
            ViewBag.Product = new SelectList(db.ProductModels, "ProdId", "ProdState", pickModel.Product);
            return View(pickModel);
        }

        // GET: PickModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickModel pickModel = db.PickModels.Find(id);
            if (pickModel == null)
            {
                return HttpNotFound();
            }
            return View(pickModel);
        }

        // POST: PickModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PickModel pickModel = db.PickModels.Find(id);
            db.PickModels.Remove(pickModel);
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
