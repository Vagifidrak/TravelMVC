using System;
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
    public class AdminOurServicesController : Controller
    {
        private TravelDB db = new TravelDB();

        // GET: TravelAdmin/AdminOurServices
        public ActionResult Index()
        {
            return View(db.OurServices.ToList());
        }

        // GET: TravelAdmin/AdminOurServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurService ourService = db.OurServices.Find(id);
            if (ourService == null)
            {
                return HttpNotFound();
            }
            return View(ourService);
        }

        // GET: TravelAdmin/AdminOurServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TravelAdmin/AdminOurServices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Header,Description,IconPhoto")] OurService ourService)
        {
            if (ModelState.IsValid)
            {
                db.OurServices.Add(ourService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ourService);
        }

        // GET: TravelAdmin/AdminOurServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurService ourService = db.OurServices.Find(id);
            if (ourService == null)
            {
                return HttpNotFound();
            }
            return View(ourService);
        }

        // POST: TravelAdmin/AdminOurServices/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Header,Description,IconPhoto")] OurService ourService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ourService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ourService);
        }

        // GET: TravelAdmin/AdminOurServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurService ourService = db.OurServices.Find(id);
            if (ourService == null)
            {
                return HttpNotFound();
            }
            return View(ourService);
        }

        // POST: TravelAdmin/AdminOurServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OurService ourService = db.OurServices.Find(id);
            db.OurServices.Remove(ourService);
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
