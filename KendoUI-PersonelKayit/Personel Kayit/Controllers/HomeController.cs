using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Personel_Kayit.Controllers
{
    public class HomeController : Controller
    {
        PersonelEntities db = new PersonelEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ekle(Personel yeni)
        {
            yeni.FKilceID = 1;
            db.Personel.Add(yeni);
            db.SaveChanges();

            return View();
        }

        public ActionResult Iller()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var model = db.Iller.ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult Ilceler()
        {

           db.Configuration.ProxyCreationEnabled = false;
            var model = db.Ilceler.ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }


    }
}