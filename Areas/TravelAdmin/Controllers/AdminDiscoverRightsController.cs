﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Travel_MVC.Models;

namespace Travel_MVC.Areas.TravelAdmin.Controllers
{
    public class AdminDiscoverRightsController : Controller
    {
        private TravelDB db = new TravelDB();

        // GET: TravelAdmin/AdminDiscoverRights
        public ActionResult Index()
        {
            return View(db.DiscoverRights.ToList());
        }

        // GET: TravelAdmin/AdminDiscoverRights/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiscoverRight discoverRight = db.DiscoverRights.Find(id);
            if (discoverRight == null)
            {
                return HttpNotFound();
            }
            return View(discoverRight);
        }

        // GET: TravelAdmin/AdminDiscoverRights/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TravelAdmin/AdminDiscoverRights/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Header,Description")] DiscoverRight discoverRight)
        {
            if (ModelState.IsValid)
            {
                db.DiscoverRights.Add(discoverRight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(discoverRight);
        }

        // GET: TravelAdmin/AdminDiscoverRights/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiscoverRight discoverRight = db.DiscoverRights.Find(id);
            if (discoverRight == null)
            {
                return HttpNotFound();
            }
            return View(discoverRight);
        }

        // POST: TravelAdmin/AdminDiscoverRights/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Header,Description")] DiscoverRight discoverRight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(discoverRight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(discoverRight);
        }

        // GET: TravelAdmin/AdminDiscoverRights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiscoverRight discoverRight = db.DiscoverRights.Find(id);
            if (discoverRight == null)
            {
                return HttpNotFound();
            }
            return View(discoverRight);
        }

        // POST: TravelAdmin/AdminDiscoverRights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiscoverRight discoverRight = db.DiscoverRights.Find(id);
            db.DiscoverRights.Remove(discoverRight);
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
