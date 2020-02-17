using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Travel_MVC.Models;

namespace Travel_MVC.Areas.TravelAdmin.Controllers
{
    public class AdminTopController : Controller
    {

        TravelDB DB = new TravelDB ();
        // GET: TravelAdmin/AdminTop
        public ActionResult Index()
        {
            return View(DB.TopSliders.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TopSlider slider,HttpPostedFileBase SliderPhoto)
        {
            if (ModelState.IsValid) {
                if (SliderPhoto != null)
                {//Şəkil əlavə etmə hissəsi burdan elave edilir
                    WebImage img = new WebImage(SliderPhoto.InputStream);//WebImage using
                    FileInfo flInfo = new FileInfo(SliderPhoto.FileName);//FileInfo using
                    string fileName = "Slider"+Guid.NewGuid()+flInfo.Extension;
                    img.Save("~/Upload/SliderPhoto/"+fileName);
                    slider.SliderPhoto = "/Upload/SliderPhoto/" + fileName;
                }
                DB.TopSliders.Add(slider);
                DB.SaveChanges();

                return RedirectToAction("index");
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound();
            TopSlider selectedSlider = DB.TopSliders.FirstOrDefault(tp => tp.id == id);
            if (selectedSlider == null) return HttpNotFound();
            return View(selectedSlider);
        }
        [HttpPost]
        public ActionResult Edit(int? id, TopSlider slider)
        {
            if (ModelState.IsValid)
            {
                TopSlider selectedSlider = DB.TopSliders.FirstOrDefault(tp => tp.id == id);
                selectedSlider.Header = slider.Header;
                selectedSlider.Description = slider.Description;
                selectedSlider.SliderPhoto = slider.SliderPhoto;
                DB.SaveChanges();
                return RedirectToAction("index");
            }

            return View();
        }
    }
}