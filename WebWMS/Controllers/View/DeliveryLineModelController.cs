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
    [Authorize]
    public class DeliveryLineModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DeliveryLineModel
        public ActionResult Index()
        {
            var deliveryLineModels = db.DeliveryLineModels.Include(d => d.DeliveryModel).Include(d => d.ProductModel);
            return View(deliveryLineModels.ToList());
        }

        // GET: DeliveryLineModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryLineModel deliveryLineModel = db.DeliveryLineModels.Find(id);
            if (deliveryLineModel == null)
            {
                return HttpNotFound();
            }
            return View(deliveryLineModel);
        }

        // GET: DeliveryLineModel/Create
        public ActionResult Create()
        {
            ViewBag.DeliveryId = new SelectList(db.DeliveryModels, "DeliveryId", "Name");
            ViewBag.Product = new SelectList(db.ProductModels, "ProdId", "ProdId");
            return View();
        }

        // POST: DeliveryLineModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeliveryLineId,Name,DeliveryId,Product,ExpectedQty,AcceptedQty,RejectedQty,isUsedForStock")] DeliveryLineModel deliveryLineModel)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryLineModels.Add(deliveryLineModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeliveryId = new SelectList(db.DeliveryModels, "DeliveryId", "Name", deliveryLineModel.DeliveryId);
            ViewBag.Product = new SelectList(db.ProductModels, "ProdId", "ProdState", deliveryLineModel.Product);
            return View(deliveryLineModel);
        }

        // GET: DeliveryLineModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryLineModel deliveryLineModel = db.DeliveryLineModels.Find(id);
            if (deliveryLineModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeliveryId = new SelectList(db.DeliveryModels, "DeliveryId", "Name", deliveryLineModel.DeliveryId);
            ViewBag.Product = new SelectList(db.ProductModels, "ProdId", "ProdState", deliveryLineModel.Product);
            return View(deliveryLineModel);
        }

        // POST: DeliveryLineModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeliveryLineId,Name,DeliveryId,Product,ExpectedQty,AcceptedQty,RejectedQty,isUsedForStock")] DeliveryLineModel deliveryLineModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryLineModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeliveryId = new SelectList(db.DeliveryModels, "DeliveryId", "Name", deliveryLineModel.DeliveryId);
            ViewBag.Product = new SelectList(db.ProductModels, "ProdId", "ProdState", deliveryLineModel.Product);
            return View(deliveryLineModel);
        }

        // GET: DeliveryLineModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryLineModel deliveryLineModel = db.DeliveryLineModels.Find(id);
            if (deliveryLineModel == null)
            {
                return HttpNotFound();
            }
            return View(deliveryLineModel);
        }

        // POST: DeliveryLineModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeliveryLineModel deliveryLineModel = db.DeliveryLineModels.Find(id);
            db.DeliveryLineModels.Remove(deliveryLineModel);
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
