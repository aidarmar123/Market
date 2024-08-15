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
using MarkelApi.Models;

namespace MarkelApi.Controllers
{
    public class ImageProductsController : ApiController
    {
        private MarketEntities db = new MarketEntities();

        // GET: api/ImageProducts
        public IQueryable<ImageProduct> GetImageProduct()
        {
            return db.ImageProduct;
        }

        // GET: api/ImageProducts/5
        [ResponseType(typeof(ImageProduct))]
        public IHttpActionResult GetImageProduct(int id)
        {
            ImageProduct imageProduct = db.ImageProduct.Find(id);
            if (imageProduct == null)
            {
                return NotFound();
            }

            return Ok(imageProduct);
        }

        // PUT: api/ImageProducts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutImageProduct(int id, ImageProduct imageProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != imageProduct.Id)
            {
                return BadRequest();
            }

            db.Entry(imageProduct).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageProductExists(id))
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

        // POST: api/ImageProducts
        [ResponseType(typeof(ImageProduct))]
        public IHttpActionResult PostImageProduct(ImageProduct imageProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ImageProduct.Add(imageProduct);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = imageProduct.Id }, imageProduct);
        }

        // DELETE: api/ImageProducts/5
        [ResponseType(typeof(ImageProduct))]
        public IHttpActionResult DeleteImageProduct(int id)
        {
            ImageProduct imageProduct = db.ImageProduct.Find(id);
            if (imageProduct == null)
            {
                return NotFound();
            }

            db.ImageProduct.Remove(imageProduct);
            db.SaveChanges();

            return Ok(imageProduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImageProductExists(int id)
        {
            return db.ImageProduct.Count(e => e.Id == id) > 0;
        }
    }
}