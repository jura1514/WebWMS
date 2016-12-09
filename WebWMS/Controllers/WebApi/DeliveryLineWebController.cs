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
    public class DeliveryLineWebController : ApiController
    {
        private WMSContext db = new WMSContext();

        // GET: api/DeliveryLineWeb
        public IQueryable<DeliveryLineModel> GetDeliveryLineModels()
        {
            return db.DeliveryLineModels;
        }

        // GET: api/DeliveryLineWeb/5
        [ResponseType(typeof(DeliveryLineModel))]
        public IHttpActionResult GetDeliveryLineModel(int id)
        {
            DeliveryLineModel deliveryLineModel = db.DeliveryLineModels.Find(id);
            if (deliveryLineModel == null)
            {
                return NotFound();
            }

            return Ok(deliveryLineModel);
        }

        // PUT: api/DeliveryLineWeb/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDeliveryLineModel(int id, DeliveryLineModel deliveryLineModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deliveryLineModel.DeliveryLineId)
            {
                return BadRequest();
            }

            db.Entry(deliveryLineModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryLineModelExists(id))
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

        // POST: api/DeliveryLineWeb
        [ResponseType(typeof(DeliveryLineModel))]
        public IHttpActionResult PostDeliveryLineModel(DeliveryLineModel deliveryLineModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DeliveryLineModels.Add(deliveryLineModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = deliveryLineModel.DeliveryLineId }, deliveryLineModel);
        }

        // DELETE: api/DeliveryLineWeb/5
        [ResponseType(typeof(DeliveryLineModel))]
        public IHttpActionResult DeleteDeliveryLineModel(int id)
        {
            DeliveryLineModel deliveryLineModel = db.DeliveryLineModels.Find(id);
            if (deliveryLineModel == null)
            {
                return NotFound();
            }

            db.DeliveryLineModels.Remove(deliveryLineModel);
            db.SaveChanges();

            return Ok(deliveryLineModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeliveryLineModelExists(int id)
        {
            return db.DeliveryLineModels.Count(e => e.DeliveryLineId == id) > 0;
        }
    }
}