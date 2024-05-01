using OgrenciWeb.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

namespace OgrenciWeb.Controllers
{
    public class OgrencilerController : Controller
    {
        OkulMvcDbEntities db = new OkulMvcDbEntities();
        public ActionResult Index()
        {
            var ogrenciler = db.TBLOgrenciler.ToList();
            return View(ogrenciler);
        }
        [HttpGet]
        public ActionResult OgrenciEkle()
        {
            List<SelectListItem> kulupler = (from items in db.TBLKulupler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = items.KulupAd,
                                                 Value = items.KulupID.ToString()
                                             }).OrderBy(item => item.Text).ToList();
            ViewBag.kulupler = kulupler;

            List<SelectListItem> cinsiyetler = new List<SelectListItem>();
            cinsiyetler.Add(new SelectListItem { Text = "Tercih Etmiyorum", Value = "0", Selected = true });
            cinsiyetler.Add(new SelectListItem { Text = "Erkek", Value = "1" });
            cinsiyetler.Add(new SelectListItem { Text = "Kadın", Value = "2" });
            ViewBag.cinsiyetler = cinsiyetler;

            return View();
        }
        [HttpPost]
        public ActionResult OgrenciEkle(TBLOgrenciler ogrenciler)
        {
            var ogrDizisi = new[] { ogrenciler.OgrAd, ogrenciler.OgrSoyad, };
            var ogrAdlari = new[] { "ogrAd", "ogrSoayad" };

            for (int i = 0; i < ogrDizisi.Length; i++)
            {
                if (ogrDizisi[i] == null)
                {
                    ModelState.AddModelError(ogrAdlari[i], $"{ogrAdlari[i]} boş geçilemez.");
                }
            }

            if (ModelState.IsValid)
            {
                //var kulup = db.TBLKulupler.Where(x => x.KulupID == ogrenciler.TBLKulupler.KulupID).FirstOrDefault();
                var kulup = db.TBLKulupler.Find(ogrenciler.TBLKulupler.KulupID);

                var cinsiyet = Request.Form["OgrCinsiyet"];
                if (cinsiyet == "0")
                    ogrenciler.OgrCinsiyet = "Tercih Etmiyorum";
                else if (cinsiyet == "1")
                    ogrenciler.OgrCinsiyet = "Erkek";
                else
                    ogrenciler.OgrCinsiyet = "Kadın";

                ogrenciler.TBLKulupler = kulup;

                if (ogrenciler.OgrCinsiyet == "Kadın")
                    ogrenciler.OgrFotograf = "/images/woman.png";
                else if (ogrenciler.OgrCinsiyet == "Erkek")
                    ogrenciler.OgrFotograf = "/images/boy.png";
                else
                    ogrenciler.OgrFotograf = null;


                db.TBLOgrenciler.Add(ogrenciler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<SelectListItem> kulupler = (from items in db.TBLKulupler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = items.KulupAd,
                                                 Value = items.KulupID.ToString()
                                             }).OrderBy(item => item.Text).ToList();
            ViewBag.kulupler = kulupler;

            List<SelectListItem> cinsiyetler = new List<SelectListItem>();
            cinsiyetler.Add(new SelectListItem { Text = "Tercih Etmiyorum", Value = "0", Selected = true });
            cinsiyetler.Add(new SelectListItem { Text = "Erkek", Value = "1" });
            cinsiyetler.Add(new SelectListItem { Text = "Kadın", Value = "2" });
            ViewBag.cinsiyetler = cinsiyetler;
            return View(ogrenciler);

        }
        public ActionResult OgrenciSil(int id)
        {
            var tut = db.TBLOgrenciler.Find(id);
            db.TBLOgrenciler.Remove(tut);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult OgrenciDuzenle(int id)
        {
            var tut = db.TBLOgrenciler.Find(id);

            List<SelectListItem> kulupler = (from items in db.TBLKulupler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = items.KulupAd,
                                                 Value = items.KulupID.ToString()
                                             }).OrderBy(item => item.Text).ToList();
            ViewBag.kulupler = kulupler;

            List<SelectListItem> cinsiyetler = new List<SelectListItem>();
            cinsiyetler.Add(new SelectListItem { Text = "Tercih Etmiyorum", Value = "0" });
            cinsiyetler.Add(new SelectListItem { Text = "Erkek", Value = "1" });
            cinsiyetler.Add(new SelectListItem { Text = "Kadın", Value = "2" });
            ViewBag.cinsiyetler = cinsiyetler;

            return View(tut);
        }
        [HttpPost]
        public ActionResult OgrenciDuzenle(TBLOgrenciler ogrenciler)
        {
            var ogrDizisi = new[] { ogrenciler.OgrAd, ogrenciler.OgrSoyad, };
            var ogrAdlari = new[] { "ogrAd", "ogrSoayad" };

            for (int i = 0; i < ogrDizisi.Length; i++)
            {
                if (ogrDizisi[i] == null)
                {
                    ModelState.AddModelError(ogrAdlari[i], $"{ogrAdlari[i]} boş geçilemez.");
                }
            }

            if (ModelState.IsValid)
            {
                var bul = db.TBLOgrenciler.Find(ogrenciler.OgrenciID);
                bul.OgrAd = ogrenciler.OgrAd;
                bul.OgrSoyad = ogrenciler.OgrSoyad;
                bul.OgrFotograf = ogrenciler.OgrFotograf;
                if (ogrenciler.OgrCinsiyet == "2")
                    bul.OgrCinsiyet = "Kadın";
                else if (ogrenciler.OgrCinsiyet == "1")
                    bul.OgrCinsiyet = "Erkek";
                else
                    bul.OgrCinsiyet = "Tercih Etmiyorum";

                if (bul.OgrCinsiyet == "Erkek")
                    bul.OgrFotograf = "/images/boy.png";
                else if (bul.OgrCinsiyet == "Kadın")
                    bul.OgrFotograf = "/images/woman.png";
                else
                    bul.OgrFotograf = null;

                bul.OgrKulup = Convert.ToByte(ogrenciler.OgrKulup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<SelectListItem> kulupler = (from items in db.TBLKulupler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = items.KulupAd,
                                                 Value = items.KulupID.ToString()
                                             }).OrderBy(item => item.Text).ToList();
            ViewBag.kulupler = kulupler;

            List<SelectListItem> cinsiyetler = new List<SelectListItem>();
            cinsiyetler.Add(new SelectListItem { Text = "Tercih Etmiyorum", Value = "0", Selected = true });
            cinsiyetler.Add(new SelectListItem { Text = "Erkek", Value = "1" });
            cinsiyetler.Add(new SelectListItem { Text = "Kadın", Value = "2" });
            ViewBag.cinsiyetler = cinsiyetler;
            return View(ogrenciler);
        }
    }
}