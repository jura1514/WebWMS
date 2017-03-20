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
    public class LocationModelApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/LocationModelApi
        public IQueryable<LocationModel> GetLocationModels()
        {
            return db.LocationModels;
        }

        // GET: api/LocationModelApi/5
        [ResponseType(typeof(LocationModel))]
        public IHttpActionResult GetLocationModel(string id)
        {
            LocationModel locationModel = db.LocationModels.Find(id);
            if (locationModel == null)
            {
                return NotFound();
            }

            return Ok(locationModel);
        }

        // PUT: api/LocationModelApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLocationModel(string id, LocationModel locationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != locationModel.LocationId)
            {
                return BadRequest();
            }

            db.Entry(locationModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationModelExists(id))
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

        // POST: api/LocationModelApi
        [ResponseType(typeof(LocationModel))]
        public IHttpActionResult PostLocationModel(LocationModel locationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LocationModels.Add(locationModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LocationModelExists(locationModel.LocationId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = locationModel.LocationId }, locationModel);
        }

        // DELETE: api/LocationModelApi/5
        [ResponseType(typeof(LocationModel))]
        public IHttpActionResult DeleteLocationModel(string id)
        {
            LocationModel locationModel = db.LocationModels.Find(id);
            if (locationModel == null)
            {
                return NotFound();
            }

            db.LocationModels.Remove(locationModel);
            db.SaveChanges();

            return Ok(locationModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LocationModelExists(string id)
        {
            return db.LocationModels.Count(e => e.LocationId == id) > 0;
        }
    }
}