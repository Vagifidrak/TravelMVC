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
    public class Section2Controller : Controller
    {
        private TravelDB db = new TravelDB();

        // GET: TravelAdmin/Section2
        public ActionResult Index()
        {
            return View(db.Section2.ToList());
        }

        // GET: TravelAdmin/Section2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section2 section2 = db.Section2.Find(id);
            if (section2 == null)
            {
                return HttpNotFound();
            }
            return View(section2);
        }

        // GET: TravelAdmin/Section2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TravelAdmin/Section2/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Photo,Header")] Section2 section2, HttpPostedFileBase sectionOne)
        {
            if (ModelState.IsValid)
            {
                if (sectionOne != null)
                {
                    if (sectionOne != null)
                    {
                        if (sectionOne.ContentLength > 0)
                        {
                            if (sectionOne.ContentType.ToLower() == "image/jpg" ||
                             sectionOne.ContentType.ToLower() == "image/png" ||
                             sectionOne.ContentType.ToLower() == "image/gif" ||
                             sectionOne.ContentType.ToLower() == "image/bmp" ||
                             sectionOne.ContentType.ToLower() == "image/jpeg"
                             )
                            {
                                WebImage img = new WebImage(sectionOne.InputStream);
                                FileInfo flInfo = new FileInfo(sectionOne.FileName);
                                string filename = "section2" + Guid.NewGuid() + flInfo.Extension;
                                img.Save("~/Upload/Slider2/" + filename);
                                section2.Photo = "/Upload/Slider2/" + filename;
                            }
                        }
                    }
                }

                db.Section2.Add(section2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: TravelAdmin/Section2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section2 section2 = db.Section2.Find(id);
            if (section2 == null)
            {
                return HttpNotFound();
            }
            return View(section2);
        }

        // POST: TravelAdmin/Section2/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Photo,Header")] Section2 section2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(section2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(section2);
        }

        // GET: TravelAdmin/Section2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section2 section2 = db.Section2.Find(id);
            if (section2 == null)
            {
                return HttpNotFound();
            }
            return View(section2);
        }

        // POST: TravelAdmin/Section2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Section2 section2 = db.Section2.Find(id);
            db.Section2.Remove(section2);
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
