using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciWeb.Models.EntityFramework;

namespace OgrenciWeb.Controllers
{
    public class DerslerController : Controller
    {
        OkulMvcDbEntities db = new OkulMvcDbEntities(); //Tablolara ulaşmak için kullanacağımız nesne(db) budur.

        public ActionResult Index() // TblDersler tablosunu listeliyor.
        {
            var dersler = db.TBLDersler.ToList();
            return View(dersler);
        }
        [HttpGet]
        public ActionResult DersEkle()
        {        
            return View(); 
        }
        [HttpPost]
        public ActionResult DersEkle(TBLDersler dersler)
        {
            db.TBLDersler.Add(dersler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersSil(int id)
        {
            var tut = db.TBLDersler.Find(id);
            db.TBLDersler.Remove(tut);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DersDuzenle(int id)
        {
            var tut = db.TBLDersler.Find(id);
            return View(tut);
        }
        [HttpPost]
        public ActionResult DersDuzenle(TBLDersler dersler)
        {
            var bul = db.TBLDersler.Find(dersler.DersID);
            bul.DersAd = dersler.DersAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}