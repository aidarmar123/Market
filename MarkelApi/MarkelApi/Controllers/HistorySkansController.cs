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
    public class HistorySkansController : ApiController
    {
        private MarketEntities db = new MarketEntities();

        // GET: api/HistorySkans
        public IQueryable<HistorySkan> GetHistorySkan()
        {
            return db.HistorySkan;
        }

        // GET: api/HistorySkans/5
        [ResponseType(typeof(HistorySkan))]
        public IHttpActionResult GetHistorySkan(int id)
        {
            HistorySkan historySkan = db.HistorySkan.Find(id);
            if (historySkan == null)
            {
                return NotFound();
            }

            return Ok(historySkan);
        }

        // PUT: api/HistorySkans/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHistorySkan(int id, HistorySkan historySkan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != historySkan.Id)
            {
                return BadRequest();
            }

            db.Entry(historySkan).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorySkanExists(id))
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

        // POST: api/HistorySkans
        [ResponseType(typeof(HistorySkan))]
        public IHttpActionResult PostHistorySkan(HistorySkan historySkan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HistorySkan.Add(historySkan);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = historySkan.Id }, historySkan);
        }

        // DELETE: api/HistorySkans/5
        [ResponseType(typeof(HistorySkan))]
        public IHttpActionResult DeleteHistorySkan(int id)
        {
            HistorySkan historySkan = db.HistorySkan.Find(id);
            if (historySkan == null)
            {
                return NotFound();
            }

            db.HistorySkan.Remove(historySkan);
            db.SaveChanges();

            return Ok(historySkan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HistorySkanExists(int id)
        {
            return db.HistorySkan.Count(e => e.Id == id) > 0;
        }
    }
}