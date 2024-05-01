using OgrenciWeb.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciWeb.Controllers
{
    public class NotlarController : Controller
    {
        OkulMvcDbEntities db = new OkulMvcDbEntities();

        public ActionResult Index()
        {
            var notlar = db.TBLNotlar.ToList();
            return View(notlar);
        }
        [HttpGet]
        public ActionResult NotEkle()
        {
            List<SelectListItem> dersler = (from items in db.TBLDersler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = items.DersAd,
                                                Value = items.DersID.ToString()
                                            }).OrderBy(item => item.Text).ToList();
            ViewBag.dersler = dersler;
            List<SelectListItem> ogrenciler = (from items in db.TBLOgrenciler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = items.OgrAd + " " + items.OgrSoyad,
                                                Value = items.OgrenciID.ToString()
                                            }).OrderBy(item => item.Text).ToList();
            ViewBag.ogrenciler = ogrenciler;
            return View();
        }
        [HttpPost]
        public ActionResult NotEkle(TBLNotlar notlar)
        {
            // Her bir notun 100'den büyük olup olmadığını kontrol et
            var notlarDizisi = new[] { notlar.Sinav1, notlar.Sinav2, notlar.Sinav3, notlar.Proje };
            var notAdlari = new[] { "Sinav1", "Sinav2", "Sinav3", "Proje" };

            for (int i = 0; i < notlarDizisi.Length; i++)
            {
                if (notlarDizisi[i] > 100)
                {
                    ModelState.AddModelError(notAdlari[i], $"{notAdlari[i]} notu 100'den büyük olamaz.");
                }
            }

            // ModelState'in geçerli olup olmadığını kontrol edin
            if (ModelState.IsValid)
            {
                var ort = Convert.ToDecimal((notlar.Sinav1) * 0.2 + (notlar.Sinav2) * 0.2 + (notlar.Sinav3) * 0.2 + (notlar.Proje) * 0.4);
                if (ort >= 50)
                    notlar.Durum = true;
                else
                    notlar.Durum = false;
                notlar.Ortalama = ort;

                var derslerr = db.TBLDersler.Find(notlar.TBLDersler.DersID);
                notlar.TBLDersler = derslerr;

                var ogrencilerr = db.TBLOgrenciler.Find(notlar.TBLOgrenciler.OgrenciID);
                notlar.TBLOgrenciler = ogrencilerr;

                db.TBLNotlar.Add(notlar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<SelectListItem> dersler = (from items in db.TBLDersler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = items.DersAd,
                                                Value = items.DersID.ToString()
                                            }).OrderBy(item => item.Text).ToList();
            ViewBag.dersler = dersler;
            List<SelectListItem> ogrenciler = (from items in db.TBLOgrenciler.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = items.OgrAd + " " + items.OgrSoyad,
                                                   Value = items.OgrenciID.ToString()
                                               }).OrderBy(item => item.Text).ToList();
            ViewBag.ogrenciler = ogrenciler;

            return View(notlar);
        }
        public ActionResult NotSil(int id)
        {
            var tut = db.TBLNotlar.Find(id);
            db.TBLNotlar.Remove(tut);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult NotDuzenle(int id) 
        {
            List<SelectListItem> dersler = (from items in db.TBLDersler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = items.DersAd,
                                                Value = items.DersID.ToString()
                                            }).OrderBy(item => item.Text).ToList();
            ViewBag.dersler = dersler;
            List<SelectListItem> ogrenciler = (from items in db.TBLOgrenciler.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = items.OgrAd + " " + items.OgrSoyad,
                                                   Value = items.OgrenciID.ToString()
                                               }).OrderBy(item => item.Text).ToList();
            ViewBag.ogrenciler = ogrenciler;

            var bul = db.TBLNotlar.Find(id);
            return View(bul);
        }
        [HttpPost]
        public ActionResult NotDuzenle(TBLNotlar notlar)
        {
            var notlarDizisi = new[] { notlar.Sinav1, notlar.Sinav2, notlar.Sinav3, notlar.Proje };
            var notAdlari = new[] { "Sinav1", "Sinav2", "Sinav3", "Proje" };

            for (int i = 0; i < notlarDizisi.Length; i++)
            {
                if (notlarDizisi[i] > 100)
                {
                    ModelState.AddModelError(notAdlari[i], $"{notAdlari[i]} notu 100'den büyük olamaz.");
                }
            }
            if (ModelState.IsValid)
            {
                var bul = db.TBLNotlar.Find(notlar.NotID);
                bul.DersID = Convert.ToByte(notlar.DersID);
                bul.OgrenciID = Convert.ToInt32(notlar.OgrenciID);
                bul.Sinav1 = notlar.Sinav1;
                bul.Sinav2 = notlar.Sinav2;
                bul.Sinav3 = notlar.Sinav3;
                bul.Proje = notlar.Proje;
                var ort = Convert.ToDecimal((bul.Sinav1) * 0.2 + (bul.Sinav2) * 0.2 + (bul.Sinav3) * 0.2 + (bul.Proje) * 0.4);
                if (ort >= 50)
                    bul.Durum = true;
                else
                    bul.Durum = false;
                bul.Ortalama = ort;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<SelectListItem> dersler = (from items in db.TBLDersler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = items.DersAd,
                                                Value = items.DersID.ToString()
                                            }).OrderBy(item => item.Text).ToList();
            ViewBag.dersler = dersler;
            List<SelectListItem> ogrenciler = (from items in db.TBLOgrenciler.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = items.OgrAd + " " + items.OgrSoyad,
                                                   Value = items.OgrenciID.ToString()
                                               }).OrderBy(item => item.Text).ToList();
            ViewBag.ogrenciler = ogrenciler;

            return View(notlar);
        }
    }
}