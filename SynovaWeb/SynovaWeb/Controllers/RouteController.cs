﻿using System;
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
    public class RouteController : Controller
    {
        private SynovaWebContext db = new SynovaWebContext();

        public string getQuery()
        {

            var test = "";
            var bookings = db.Bookings.ToList();
            var routes = db.Routes.ToList();
            var shipments = db.Shipments.ToList();
            var query = from Route in routes
                        where Route.area == "987"
                        select new
                        {
                            zzz = Route.name
                        };

            foreach (var Route in query)
            {
                test = Route.zzz;
            }
         
            return test;
        }
        public void getQQ()
        {      
            HttpContext.Response.Write("<script>alert('4564654');</script>");
            RedirectToAction("Index");
        }
        // GET: Route
        public ActionResult Index()
        {
            return View(db.Routes.ToList());
        }

        // GET: Route/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        // GET: Route/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Route/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name,area")] Route route)
        {
          
            if (ModelState.IsValid)
            {
                route.name = getQuery();
                db.Routes.Add(route);
                db.SaveChanges();       
                return RedirectToAction("Index");
            }

            return View(route);
        }

        // GET: Route/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        // POST: Route/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,area")] Route route)
        {
            if (ModelState.IsValid)
            {
                db.Entry(route).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(route);
        }

        // GET: Route/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        // POST: Route/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Route route = db.Routes.Find(id);
            db.Routes.Remove(route);
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
