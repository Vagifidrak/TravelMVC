using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Travel_MVC.Models;

namespace Travel_MVC.Areas.TravelAdmin.Controllers
{
    public class AllToursController : Controller
    {
        private TravelDB db = new TravelDB();

        // GET: TravelAdmin/AllTours
        public ActionResult Index()
        {
            return View(db.AllTours.ToList());
        }

        // GET: TravelAdmin/AllTours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllTour allTour = db.AllTours.Find(id);
            if (allTour == null)
            {
                return HttpNotFound();
            }
            return View(allTour);
        }

        // GET: TravelAdmin/AllTours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TravelAdmin/AllTours/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Header,Description,Photo,Price")] AllTour allTour,HttpPostedFileBase allTours)
        {
            if (ModelState.IsValid)
            {
                if (allTours != null)
                {
                    if (allTours != null)
                    {
                        if (allTours.ContentLength > 0)
                        {
                           if( allTours.ContentType.ToLower() == "image/jpg" ||
                            allTours.ContentType.ToLower() == "image/png" ||
                            allTours.ContentType.ToLower() == "image/gif" ||
                            allTours.ContentType.ToLower() == "image/bmp" ||
                            allTours.ContentType.ToLower() == "image/jpeg")
                            {
                                WebImage img = new WebImage(allTours.InputStream);
                                FileInfo flInfo = new FileInfo(allTours.FileName);
                                string filename = "allTours" + Guid.NewGuid() + flInfo.Extension;
                                img.Save("~/Upload/AllTours/" + filename);
                                allTour.Photo = "/Upload/AllTours/" + filename;
                            }

                        }
                    }
                }
                db.AllTours.Add(allTour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(allTour);
        }

        // GET: TravelAdmin/AllTours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllTour allTour = db.AllTours.Find(id);
            if (allTour == null)
            {
                return HttpNotFound();
            }
            return View(allTour);
        }

        // POST: TravelAdmin/AllTours/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Header,Description,Photo,Price")] AllTour allTour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allTour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(allTour);
        }

        // GET: TravelAdmin/AllTours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllTour allTour = db.AllTours.Find(id);
            if (allTour == null)
            {
                return HttpNotFound();
            }
            return View(allTour);
        }

        // POST: TravelAdmin/AllTours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AllTour allTour = db.AllTours.Find(id);
            db.AllTours.Remove(allTour);
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
