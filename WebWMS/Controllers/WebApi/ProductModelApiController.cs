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
    public class ProductModelApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ProductModelApi
        public IQueryable<ProductModel> GetProductModels()
        {
            return db.ProductModels;
        }

        // GET: api/ProductModelApi/5
        [ResponseType(typeof(ProductModel))]
        public IHttpActionResult GetProductModel(string id)
        {
            ProductModel productModel = db.ProductModels.Find(id);
            if (productModel == null)
            {
                return NotFound();
            }

            return Ok(productModel);
        }

        // PUT: api/ProductModelApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductModel(string id, ProductModel productModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productModel.ProdId)
            {
                return BadRequest();
            }

            db.Entry(productModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductModelExists(id))
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

        // POST: api/ProductModelApi
        [ResponseType(typeof(ProductModel))]
        public IHttpActionResult PostProductModel(ProductModel productModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductModels.Add(productModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProductModelExists(productModel.ProdId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = productModel.ProdId }, productModel);
        }

        // DELETE: api/ProductModelApi/5
        [ResponseType(typeof(ProductModel))]
        public IHttpActionResult DeleteProductModel(string id)
        {
            ProductModel productModel = db.ProductModels.Find(id);
            if (productModel == null)
            {
                return NotFound();
            }

            db.ProductModels.Remove(productModel);
            db.SaveChanges();

            return Ok(productModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductModelExists(string id)
        {
            return db.ProductModels.Count(e => e.ProdId == id) > 0;
        }
    }
}