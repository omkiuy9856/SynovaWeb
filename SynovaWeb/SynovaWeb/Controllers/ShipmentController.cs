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
using System.Data.Entity.Core.Objects;
using System.Web.UI;

namespace SynovaWeb.Controllers
{
    public class ShipmentController : Controller
    {
        private SynovaWebContext db = new SynovaWebContext();

        public string getQuery(int booking_no)
        {
            //HttpContext.Response.Write("<script>alert('" + booking_no + "');</script>");
            var b_no = booking_no;
            var customer_name="";
            var bookings = db.Bookings.ToList();
            var query = from Booking in bookings
                        where Booking.BookingID == b_no
                        select new
                        {
                            zzz = Booking.Customers.Name
                        };
          
            foreach (var Booking in query)
            {
                customer_name = Booking.zzz;
            }
            
            return customer_name;
        }

        // GET: Shipment
        public ActionResult Index(string searchString)
        {
            var shipments = from s in db.Shipments
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                var number = Convert.ToInt32(searchString);
                //HttpContext.Response.Write("<script>alert('" + number + "');</script>");

                shipments = shipments.Where(s => s.Customer_name.Contains(searchString));
               
                    //db.Shipments.Include(s => s.Booking).Include(s => s.Status);  
            }
           // var shipments = db.Shipments.Include(s => s.Booking).Include(s => s.Status);
            return View(shipments);
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
            
            ViewBag.BookingID = new SelectList(db.Bookings, "BookingID", "BookingNo");
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
                shipment.Customer_name = getQuery(shipment.BookingID);  
                db.Shipments.Add(shipment);
                db.SaveChanges();  
                return RedirectToAction("Index");
            }

            ViewBag.BookingID = new SelectList(db.Bookings, "BookingID", "BookingNo", shipment.BookingID);
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
            ViewBag.BookingID = new SelectList(db.Bookings, "BookingID", "BookingNo", shipment.BookingID);
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
                shipment.Customer_name = getQuery(shipment.BookingID);
                db.Entry(shipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookingID = new SelectList(db.Bookings, "BookingID", "BookingNo", shipment.BookingID);
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
