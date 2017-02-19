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
    public class LocationModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LocationModel
        public ActionResult Index()
        {
            return View(db.LocationModels.ToList());
        }

        // GET: LocationModel/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationModel locationModel = db.LocationModels.Find(id);
            if (locationModel == null)
            {
                return HttpNotFound();
            }
            return View(locationModel);
        }

        // GET: LocationModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocationModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocationId,LocState,StateChangeTime")] LocationModel locationModel)
        {
            if (ModelState.IsValid)
            {
                db.LocationModels.Add(locationModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(locationModel);
        }

        // GET: LocationModel/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationModel locationModel = db.LocationModels.Find(id);
            if (locationModel == null)
            {
                return HttpNotFound();
            }
            return View(locationModel);
        }

        // POST: LocationModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocationId,LocState,StateChangeTime")] LocationModel locationModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locationModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locationModel);
        }

        // GET: LocationModel/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationModel locationModel = db.LocationModels.Find(id);
            if (locationModel == null)
            {
                return HttpNotFound();
            }
            return View(locationModel);
        }

        // POST: LocationModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LocationModel locationModel = db.LocationModels.Find(id);
            db.LocationModels.Remove(locationModel);
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
