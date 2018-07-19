using projekt_7_2_vj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekt_7_2_vj.Controllers
{
    public class ArtiklController : Controller
    {
        string[] kate = { "Voce", "Povrce", "Meso" };

        // GET: Artikl
        public ActionResult Dodaj()
        {
            ViewBag.Kategorija = kate;

            return View();
        }

        public ActionResult Unesi(Artikl ar)
        {
            ViewBag.Kategorija = kate;
            List<Artikl> db;

            if (ModelState.IsValid)
            {
                if (Session.IsNewSession)
                {
                    db = new List<Artikl>();
                    db.Add(ar);
                    Session["Artikli"] = db;
                }
                else
                {
                    db = (List<Artikl>)Session["Artikli"];
                    db.Add(ar);
                    Session["Artikli"] = db;
                }

                return View(db);
            }
            else
            {
                return View("Dodaj");
            }
        }
    }
}