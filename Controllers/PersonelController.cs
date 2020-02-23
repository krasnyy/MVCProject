using MVCProject.Models.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.ViewModels;

namespace MVCProject.Controllers
{
    public class PersonelController : Controller
    {
        TEST3Entities1 db = new TEST3Entities1();
        public ActionResult Index()
        {
            var model = db.Personel.ToList();
            return View(model);
        }
        public ActionResult Yeni()
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = db.Departman.ToList(),
                Personel = new Personel()
            };
            return View("PersonelForm", model);
        }

        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Personel personel)
        {
            if(!ModelState.IsValid)
            {
                var model = new PersonelFormViewModel()
                {
                    Departmanlar = db.Departman.ToList(),
                    Personel = personel
                };
                return View("PersonelForm", model);
            }
            if(personel.id==0)
            {
                db.Personel.Add(personel);
            }
            else
            {
                db.Entry(personel).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Guncelle(int id)
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = db.Departman.ToList(),
                Personel = db.Personel.Find(id)
            };
            return View("PersonelForm", model);
        }

        public ActionResult Sil(int id)
        {
            var silinecekPersonel = db.Personel.Find(id);
            if(silinecekPersonel==null)
            {
                return HttpNotFound();
            }
            db.Personel.Remove(silinecekPersonel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}