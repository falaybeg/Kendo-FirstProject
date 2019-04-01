using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Models;
using System.Net;
using System.Data.Entity;

namespace Kendo.Controllers
{
    public class HomeController : Controller
    {
        
        DBEntities db = new DBEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        
       
        [HttpPost]
        public ActionResult Ekle(Musteri bilgi)
        {
            db.Musteri.Add(bilgi);
            db.SaveChanges();
            return Json(bilgi,  JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete ()
        {

            return Json(null, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Guncelle(Musteri model)
        {
            if(ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
               
            }
            return View(model);
        }

        public JsonResult Veriler()
        {
            return Json(db.Musteri.ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}