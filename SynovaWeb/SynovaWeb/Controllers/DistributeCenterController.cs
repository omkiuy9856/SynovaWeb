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
    public class DistributeCenterController : Controller
    {
        private SynovaWebContext db = new SynovaWebContext();

        // GET: DistributeCenter
        public ActionResult Index()
        {
            var distributeCenters = db.DistributeCenters.Include(d => d.Driver).Include(d => d.Shipment).Include(d => d.User);
            return View(distributeCenters.ToList());
        }

        // GET: DistributeCenter/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DistributeCenter distributeCenter = db.DistributeCenters.Find(id);
            if (distributeCenter == null)
            {
                return HttpNotFound();
            }
            return View(distributeCenter);
        }

        // GET: DistributeCenter/Create
        public ActionResult Create()
        {
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverId", "name");
            ViewBag.ShipmentID = new SelectList(db.Shipments, "ShipmentID", "ShipmentNo");
            ViewBag.UserID = new SelectList(db.Users, "UserId", "name");
            return View();
        }

        // POST: DistributeCenter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ShipmentID,UserID,DriverID")] DistributeCenter distributeCenter)
        {
            if (ModelState.IsValid)
            {
                db.DistributeCenters.Add(distributeCenter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DriverID = new SelectList(db.Drivers, "DriverId", "name", distributeCenter.DriverID);
            ViewBag.ShipmentID = new SelectList(db.Shipments, "ShipmentID", "ShipmentNo", distributeCenter.ShipmentID);
            ViewBag.UserID = new SelectList(db.Users, "UserId", "name", distributeCenter.UserID);
            return View(distributeCenter);
        }

        // GET: DistributeCenter/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DistributeCenter distributeCenter = db.DistributeCenters.Find(id);
            if (distributeCenter == null)
            {
                return HttpNotFound();
            }
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverId", "name", distributeCenter.DriverID);
            ViewBag.ShipmentID = new SelectList(db.Shipments, "ShipmentID", "ShipmentNo", distributeCenter.ShipmentID);
            ViewBag.UserID = new SelectList(db.Users, "UserId", "name", distributeCenter.UserID);
            return View(distributeCenter);
        }

        // POST: DistributeCenter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ShipmentID,UserID,DriverID")] DistributeCenter distributeCenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(distributeCenter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DriverID = new SelectList(db.Drivers, "DriverId", "name", distributeCenter.DriverID);
            ViewBag.ShipmentID = new SelectList(db.Shipments, "ShipmentID", "ShipmentNo", distributeCenter.ShipmentID);
            ViewBag.UserID = new SelectList(db.Users, "UserId", "name", distributeCenter.UserID);
            return View(distributeCenter);
        }

        // GET: DistributeCenter/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DistributeCenter distributeCenter = db.DistributeCenters.Find(id);
            if (distributeCenter == null)
            {
                return HttpNotFound();
            }
            return View(distributeCenter);
        }

        // POST: DistributeCenter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DistributeCenter distributeCenter = db.DistributeCenters.Find(id);
            db.DistributeCenters.Remove(distributeCenter);
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
