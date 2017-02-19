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
    public class DeliveryModelApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/DeliveryModelApi
        public IQueryable<DeliveryModel> GetDeliveryModels()
        {
            return db.DeliveryModels;
        }

        // GET: api/DeliveryModelApi/5
        [ResponseType(typeof(DeliveryModel))]
        public IHttpActionResult GetDeliveryModel(int id)
        {
            DeliveryModel deliveryModel = db.DeliveryModels.Find(id);
            if (deliveryModel == null)
            {
                return NotFound();
            }

            return Ok(deliveryModel);
        }

        // PUT: api/DeliveryModelApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDeliveryModel(int id, DeliveryModel deliveryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deliveryModel.DeliveryId)
            {
                return BadRequest();
            }

            db.Entry(deliveryModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryModelExists(id))
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

        // POST: api/DeliveryModelApi
        [ResponseType(typeof(DeliveryModel))]
        public IHttpActionResult PostDeliveryModel(DeliveryModel deliveryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DeliveryModels.Add(deliveryModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = deliveryModel.DeliveryId }, deliveryModel);
        }

        // DELETE: api/DeliveryModelApi/5
        [ResponseType(typeof(DeliveryModel))]
        public IHttpActionResult DeleteDeliveryModel(int id)
        {
            DeliveryModel deliveryModel = db.DeliveryModels.Find(id);
            if (deliveryModel == null)
            {
                return NotFound();
            }

            db.DeliveryModels.Remove(deliveryModel);
            db.SaveChanges();

            return Ok(deliveryModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeliveryModelExists(int id)
        {
            return db.DeliveryModels.Count(e => e.DeliveryId == id) > 0;
        }
    }
}