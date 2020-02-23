using MVCProject.Models.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class DepartmanController : Controller
    {
        TEST3Entities1 db = new TEST3Entities1();

        public ActionResult Index()
        {
            var model = db.Departman.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Yeni()
        {
            return View("DepartmanForm", new Departman());
        }

        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Departman departman)
        {
            if(!ModelState.IsValid)
            {
                return View("DepartmanForm");
            }
            if (departman.id == 0)
            {
                db.Departman.Add(departman);
            }
            else
            {
                var guncellenicekdepartman = db.Departman.Find(departman.id);
                if(guncellenicekdepartman==null)
                {
                    return HttpNotFound();
                }
                guncellenicekdepartman.Adi = departman.Adi;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Departman");
        }

        public ActionResult Guncelle(int id)
        {
            var model = db.Departman.Find(id);
            if(model==null)
            {
                return HttpNotFound();
            }
            return View("DepartmanForm", model);
        }

        public ActionResult Sil(int id)
        {
            var silinecekDepartman = db.Departman.Find(id);
            if(silinecekDepartman==null)
            {
                return HttpNotFound();
            }
            db.Departman.Remove(silinecekDepartman);
            db.SaveChanges();
            return RedirectToAction("Index", "Departman");

        }



    }
}