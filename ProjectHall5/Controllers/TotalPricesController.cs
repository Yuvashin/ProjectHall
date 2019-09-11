using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectHall5.Models;

namespace ProjectHall5.Controllers
{
    public class TotalPricesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TotalPrices
        public ActionResult Index()
        {
            var totalPrices = db.TotalPrices.Include(t => t.UserCatering).Include(t => t.UserDecor).Include(t => t.Venue);
            return View(totalPrices.ToList());
        }

        // GET: TotalPrices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TotalPrice totalPrice = db.TotalPrices.Find(id);
            if (totalPrice == null)
            {
                return HttpNotFound();
            }
            return View(totalPrice);
        }

        // GET: TotalPrices/Create
        public ActionResult Create()
        {
            ViewBag.UserCateringID = new SelectList(db.UserCaterings, "UserCateringID", "Email");
            ViewBag.UserDecorID = new SelectList(db.UserDecors, "UserDecorID", "Email");
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName");
            return View();
        }

        // POST: TotalPrices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TotalPricesID,UserDecorID,UserCateringID,VenueID,TotalBookingPrice,TotalVenuePrice,TotalDecorPrice,TotalCateringPrice")] TotalPrice totalPrice)
        {
            if (ModelState.IsValid)
            {
                db.TotalPrices.Add(totalPrice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserCateringID = new SelectList(db.UserCaterings, "UserCateringID", "Email", totalPrice.UserCateringID);
            ViewBag.UserDecorID = new SelectList(db.UserDecors, "UserDecorID", "Email", totalPrice.UserDecorID);
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName", totalPrice.VenueID);
            return View(totalPrice);
        }

        // GET: TotalPrices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TotalPrice totalPrice = db.TotalPrices.Find(id);
            if (totalPrice == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserCateringID = new SelectList(db.UserCaterings, "UserCateringID", "Email", totalPrice.UserCateringID);
            ViewBag.UserDecorID = new SelectList(db.UserDecors, "UserDecorID", "Email", totalPrice.UserDecorID);
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName", totalPrice.VenueID);
            return View(totalPrice);
        }

        // POST: TotalPrices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TotalPricesID,UserDecorID,UserCateringID,VenueID,TotalBookingPrice,TotalVenuePrice,TotalDecorPrice,TotalCateringPrice")] TotalPrice totalPrice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(totalPrice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserCateringID = new SelectList(db.UserCaterings, "UserCateringID", "Email", totalPrice.UserCateringID);
            ViewBag.UserDecorID = new SelectList(db.UserDecors, "UserDecorID", "Email", totalPrice.UserDecorID);
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName", totalPrice.VenueID);
            return View(totalPrice);
        }

        // GET: TotalPrices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TotalPrice totalPrice = db.TotalPrices.Find(id);
            if (totalPrice == null)
            {
                return HttpNotFound();
            }
            return View(totalPrice);
        }

        // POST: TotalPrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TotalPrice totalPrice = db.TotalPrices.Find(id);
            db.TotalPrices.Remove(totalPrice);
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
