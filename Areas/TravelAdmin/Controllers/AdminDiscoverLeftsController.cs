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
    public class AdminDiscoverLeftsController : Controller
    {
        private TravelDB db = new TravelDB();

        // GET: TravelAdmin/AdminDiscoverLefts
        public ActionResult Index()
        {
            return View(db.DiscoverLefts.ToList());
        }

        // GET: TravelAdmin/AdminDiscoverLefts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiscoverLeft discoverLeft = db.DiscoverLefts.Find(id);
            if (discoverLeft == null)
            {
                return HttpNotFound();
            }
            return View(discoverLeft);
        }

        // GET: TravelAdmin/AdminDiscoverLefts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TravelAdmin/AdminDiscoverLefts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Photo")] DiscoverLeft discoverLeft, HttpPostedFileBase LeftPhoto)
        {
            if (ModelState.IsValid)
            {
                if (LeftPhoto != null)
                {
                    if (LeftPhoto.ContentLength > 0)
                    {
                        if (
                            LeftPhoto.ContentType.ToLower() == "image/jpg" ||
                            LeftPhoto.ContentType.ToLower() == "image/png" ||
                            LeftPhoto.ContentType.ToLower() == "image/gif" ||
                            LeftPhoto.ContentType.ToLower() == "image/bmp" ||
                            LeftPhoto.ContentType.ToLower() == "image/jpeg"
                            )
                        {
                            WebImage img = new WebImage(LeftPhoto.InputStream);
                            FileInfo flInfo = new FileInfo(LeftPhoto.FileName);
                            string filename = "DiscoLeft" + Guid.NewGuid() + flInfo.Extension;
                            img.Save("~/Upload/DiscoverPhoto/"+filename);
                            discoverLeft.Photo = "/Upload/DiscoverPhoto/"+filename;
                        }
                    }
                }
                db.DiscoverLefts.Add(discoverLeft);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(discoverLeft);
        }

        // GET: TravelAdmin/AdminDiscoverLefts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiscoverLeft discoverLeft = db.DiscoverLefts.Find(id);
            if (discoverLeft == null)
            {
                return HttpNotFound();
            }
            return View(discoverLeft);
        }

        // POST: TravelAdmin/AdminDiscoverLefts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Photo")] DiscoverLeft discoverLeft)
        {
            if (ModelState.IsValid)
            {
                db.Entry(discoverLeft).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(discoverLeft);
        }

        // GET: TravelAdmin/AdminDiscoverLefts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiscoverLeft discoverLeft = db.DiscoverLefts.Find(id);
            if (discoverLeft == null)
            {
                return HttpNotFound();
            }
            return View(discoverLeft);
        }

        // POST: TravelAdmin/AdminDiscoverLefts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiscoverLeft discoverLeft = db.DiscoverLefts.Find(id);
            db.DiscoverLefts.Remove(discoverLeft);
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
