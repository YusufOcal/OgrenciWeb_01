using OgrenciWeb.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciWeb.Controllers
{
    public class KuluplerController : Controller
    {
        OkulMvcDbEntities db = new OkulMvcDbEntities();
        public ActionResult Index()
        {
            var kulupler = db.TBLKulupler.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult KulupEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KulupEkle(TBLKulupler kulupler)
        {
            db.TBLKulupler.Add(kulupler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KulupSil(int id)
        {
            var tut = db.TBLKulupler.Find(id);
            db.TBLKulupler.Remove(tut);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult KulupDuzenle(int id)
        {
            var bul = db.TBLKulupler.Find(id);
            return View(bul);
        }
        [HttpPost]
        public ActionResult KulupDuzenle(TBLKulupler kulupler)
        {
            var tut = db.TBLKulupler.Find(kulupler.KulupID); 
            tut.KulupAd = kulupler.KulupAd;
            tut.KulupKontenjan = kulupler.KulupKontenjan;
            db.SaveChanges();   // BU OLMADAN GÜNCELLEME İŞLEMİ GERÇEKLEŞMİYOR.
            return RedirectToAction("Index");
        }
    }
}