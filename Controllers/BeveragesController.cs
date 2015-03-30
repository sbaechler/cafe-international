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
    public class BeveragesController : ApiController
    {
        private CafeContext db = new CafeContext();

        // GET: api/Beverages
        public IQueryable<Beverage> GetBeverages()
        {
            return db.Beverages;
        }

        // GET: api/Beverages/5
        [ResponseType(typeof(Beverage))]
        public IHttpActionResult GetBeverage(int id)
        {
            Beverage beverage = db.Beverages.Find(id);
            if (beverage == null)
            {
                return NotFound();
            }

            return Ok(beverage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BeverageExists(int id)
        {
            return db.Beverages.Count(e => e.ID == id) > 0;
        }
    }
}