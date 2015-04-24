using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CafeInternational.DAL;
using CafeInternational.Models;
/*
namespace CafeInternational.Controllers
{
    public class CountryHasBeveragesController : Controller
    {
        private CafeContext db = new CafeContext();

        // GET: CountryHasBeverages
        public ActionResult Index()
        {
            var countryHasBeverages = db.CountryHasBeverages.Include(c => c.Beverage).Include(c => c.Countries);
            return View(countryHasBeverages.ToList());
        }

        // GET: CountryHasBeverages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryHasBeverage countryHasBeverage = db.CountryHasBeverages.Find(id);
            if (countryHasBeverage == null)
            {
                return HttpNotFound();
            }
            return View(countryHasBeverage);
        }

        // GET: CountryHasBeverages/Create
        public ActionResult Create()
        {
            ViewBag.BeverageID = new SelectList(db.Beverages, "ID", "Name");
            ViewBag.CountryISO2 = new SelectList(db.Countries, "ISO2", "Name");
            return View();
        }

        // POST: CountryHasBeverages/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BeverageID,CountryISO2,Popularity,Name,Language")] CountryHasBeverage countryHasBeverage)
        {
            if (ModelState.IsValid)
            {
                db.CountryHasBeverages.Add(countryHasBeverage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BeverageID = new SelectList(db.Beverages, "ID", "Name", countryHasBeverage.BeverageID);
            ViewBag.CountryISO2 = new SelectList(db.Countries, "ISO2", "Name", countryHasBeverage.CountryISO2);
            return View(countryHasBeverage);
        }

        // GET: CountryHasBeverages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryHasBeverage countryHasBeverage = db.CountryHasBeverages.Find(id);
            if (countryHasBeverage == null)
            {
                return HttpNotFound();
            }
            ViewBag.BeverageID = new SelectList(db.Beverages, "ID", "Name", countryHasBeverage.BeverageID);
            ViewBag.CountryISO2 = new SelectList(db.Countries, "ISO2", "Name", countryHasBeverage.CountryISO2);
            return View(countryHasBeverage);
        }

        // POST: CountryHasBeverages/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BeverageID,CountryISO2,Popularity,Name,Language")] CountryHasBeverage countryHasBeverage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(countryHasBeverage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BeverageID = new SelectList(db.Beverages, "ID", "Name", countryHasBeverage.BeverageID);
            ViewBag.CountryISO2 = new SelectList(db.Countries, "ISO2", "Name", countryHasBeverage.CountryISO2);
            return View(countryHasBeverage);
        }

        // GET: CountryHasBeverages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryHasBeverage countryHasBeverage = db.CountryHasBeverages.Find(id);
            if (countryHasBeverage == null)
            {
                return HttpNotFound();
            }
            return View(countryHasBeverage);
        }

        // POST: CountryHasBeverages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CountryHasBeverage countryHasBeverage = db.CountryHasBeverages.Find(id);
            db.CountryHasBeverages.Remove(countryHasBeverage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
*/