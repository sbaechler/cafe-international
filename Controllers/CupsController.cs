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
using CafeInternational.DAL;
using CafeInternational.Models;

namespace CafeInternational.Controllers
{
    public class CupsController : ApiController
    {
        private CafeContext db = new CafeContext();

        // GET: api/Cups
        public IQueryable<Cup> GetCups()
        {
            return db.Cups;
        }

        // GET: api/Cups/5
        [ResponseType(typeof(Cup))]
        public IHttpActionResult GetCup(int id)
        {
            Cup cup = db.Cups.Find(id);
            if (cup == null)
            {
                return NotFound();
            }

            return Ok(cup);
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CupExists(int id)
        {
            return db.Cups.Count(e => e.ID == id) > 0;
        }
    }
}