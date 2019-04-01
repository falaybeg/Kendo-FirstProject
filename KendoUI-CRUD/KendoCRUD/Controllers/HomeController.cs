using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace KendoCRUD.Controllers
{
    public class HomeController : Controller
    {
        DBEntities db = new DBEntities();

        // GET: Home
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult ReadCustomer()
        {
            var model = db.Musteri.ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult CreateCustomer(Musteri customer)
        {
            if (ModelState.IsValid)
            {
                db.Musteri.Add(customer);
                db.SaveChanges();
                return Json(customer, JsonRequestBehavior.AllowGet);
            }
            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(Musteri updatedCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(updatedCustomer).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(updatedCustomer);
        }


        [HttpPost]
        public ActionResult DeleteCustomer(int? id)
        {
            if (id != null)
            {
                var model = db.Musteri.Find(id);
                db.Musteri.Remove(model);
                db.SaveChanges();
                return Json(model, JsonRequestBehavior.AllowGet);
            }

            return Json(null);
            
        }




    }
}