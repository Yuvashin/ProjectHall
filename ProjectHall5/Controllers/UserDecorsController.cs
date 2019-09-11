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
    public class UserDecorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserDecors
        public ActionResult Index()
        {
            var userDecors = db.UserDecors.Include(u => u.Booking).Include(u => u.Decor);
            return View(userDecors.ToList());
        }

        // GET: UserDecors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDecor userDecor = db.UserDecors.Find(id);
            if (userDecor == null)
            {
                return HttpNotFound();
            }
            return View(userDecor);
        }

        // GET: UserDecors/Create
        public ActionResult Create()
        {
            ViewBag.BookingID = new SelectList(db.Bookings, "BookingID", "OccasionType");
            ViewBag.DecorID = new SelectList(db.Decors, "DecorID", "DecorPackage");
            return View();
        }

        // POST: UserDecors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserDecorID,Email,DecorID,BookingID,DecorCost,DecorNumberGuest")] UserDecor userDecor)
        {
            if (ModelState.IsValid)
            {
                db.UserDecors.Add(userDecor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookingID = new SelectList(db.Bookings, "BookingID", "OccasionType", userDecor.BookingID);
            ViewBag.DecorID = new SelectList(db.Decors, "DecorID", "DecorPackage", userDecor.DecorID);
            return View(userDecor);
        }

        // GET: UserDecors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDecor userDecor = db.UserDecors.Find(id);
            if (userDecor == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookingID = new SelectList(db.Bookings, "BookingID", "OccasionType", userDecor.BookingID);
            ViewBag.DecorID = new SelectList(db.Decors, "DecorID", "DecorPackage", userDecor.DecorID);
            return View(userDecor);
        }

        // POST: UserDecors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserDecorID,Email,DecorID,BookingID,DecorCost,DecorNumberGuest")] UserDecor userDecor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDecor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookingID = new SelectList(db.Bookings, "BookingID", "OccasionType", userDecor.BookingID);
            ViewBag.DecorID = new SelectList(db.Decors, "DecorID", "DecorPackage", userDecor.DecorID);
            return View(userDecor);
        }

        // GET: UserDecors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDecor userDecor = db.UserDecors.Find(id);
            if (userDecor == null)
            {
                return HttpNotFound();
            }
            return View(userDecor);
        }

        // POST: UserDecors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserDecor userDecor = db.UserDecors.Find(id);
            db.UserDecors.Remove(userDecor);
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
