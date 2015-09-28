using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SynovaWeb.DAL;
using SynovaWeb.Models;

namespace SynovaWeb.Controllers
{
    public class ShipmentController : Controller
    {
        private SynovaWebContext db = new SynovaWebContext();

        // GET: Shipment
        public ActionResult Index()
        {
            var shipments = db.Shipments.Include(s => s.Booking).Include(s => s.Status);
            return View(shipments.ToList());
        }

        // GET: Shipment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = db.Shipments.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            return View(shipment);
        }

        // GET: Shipment/Create
        public ActionResult Create()
        {
            ViewBag.BookingID = new SelectList(db.Bookings, "BookingID", "BookingID");
            ViewBag.StatusID = new SelectList(db.Status, "StatusId", "status_name");
            return View();
        }

        // POST: Shipment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShipmentID,ShipmentNo,BookingID,Customer_name,receiver_name,receiver_address,receiver_zipcode,receiver_tel,quantity,price,shipment_date,pickup_date,weight,StatusID")] Shipment shipment)
        {
            if (ModelState.IsValid)
            {
                db.Shipments.Add(shipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookingID = new SelectList(db.Bookings, "BookingID", "BookingID", shipment.BookingID);
            ViewBag.StatusID = new SelectList(db.Status, "StatusId", "status_name", shipment.StatusID);
            return View(shipment);
        }

        // GET: Shipment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = db.Shipments.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookingID = new SelectList(db.Bookings, "BookingID", "BookingID", shipment.BookingID);
            ViewBag.StatusID = new SelectList(db.Status, "StatusId", "status_name", shipment.StatusID);
            return View(shipment);
        }

        // POST: Shipment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShipmentID,ShipmentNo,BookingID,Customer_name,receiver_name,receiver_address,receiver_zipcode,receiver_tel,quantity,price,shipment_date,pickup_date,weight,StatusID")] Shipment shipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookingID = new SelectList(db.Bookings, "BookingID", "BookingID", shipment.BookingID);
            ViewBag.StatusID = new SelectList(db.Status, "StatusId", "status_name", shipment.StatusID);
            return View(shipment);
        }

        // GET: Shipment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = db.Shipments.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            return View(shipment);
        }

        // POST: Shipment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shipment shipment = db.Shipments.Find(id);
            db.Shipments.Remove(shipment);
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
