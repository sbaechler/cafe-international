using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CafeInternational.DAL;
using CafeInternational.Models;

namespace CafeInternational.Controllers
{
    public class CountriesController : ApiController
    {
        private CafeContext db = new CafeContext();

        // GET: api/Countries
        public IQueryable<Country> GetCountries()
        {
            return db.Countries;
        }

        // GET: api/Countries/5
        [ResponseType(typeof(Country))]
        public async Task<IHttpActionResult> GetCountry(string id)
        {
            Country country = await db.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CountryExists(string id)
        {
            return db.Countries.Count(e => e.ISO2 == id) > 0;
        }
    }
}