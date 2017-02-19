using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebWMS.Models;

namespace WebWMS.Controllers.WebApi
{
    public class PickModelApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/PickModelApi
        public IQueryable<PickModel> GetPickModels()
        {
            return db.PickModels;
        }

        // GET: api/PickModelApi/5
        [ResponseType(typeof(PickModel))]
        public IHttpActionResult GetPickModel(int id)
        {
            PickModel pickModel = db.PickModels.Find(id);
            if (pickModel == null)
            {
                return NotFound();
            }

            return Ok(pickModel);
        }

        // PUT: api/PickModelApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPickModel(int id, PickModel pickModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pickModel.PickId)
            {
                return BadRequest();
            }

            db.Entry(pickModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PickModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PickModelApi
        [ResponseType(typeof(PickModel))]
        public IHttpActionResult PostPickModel(PickModel pickModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PickModels.Add(pickModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pickModel.PickId }, pickModel);
        }

        // DELETE: api/PickModelApi/5
        [ResponseType(typeof(PickModel))]
        public IHttpActionResult DeletePickModel(int id)
        {
            PickModel pickModel = db.PickModels.Find(id);
            if (pickModel == null)
            {
                return NotFound();
            }

            db.PickModels.Remove(pickModel);
            db.SaveChanges();

            return Ok(pickModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PickModelExists(int id)
        {
            return db.PickModels.Count(e => e.PickId == id) > 0;
        }
    }
}