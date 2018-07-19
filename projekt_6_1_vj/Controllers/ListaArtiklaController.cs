using projekt_6_1_vj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekt_6_1_vj.Controllers
{
    public class ListaArtiklaController : Controller
    {

        public  ActionResult UnesiArtikl()
        {
            string[] katgorija = { "Voce", "Povrce", "Meso" };
            ViewBag.Kategorija = katgorija;
            return View();
        }


        [HttpPost]
        public ActionResult DodajArtikl(Artikl artikl)
        {
            var artikli = new List<Artikl>();

            if (Session.IsNewSession)
            {
                artikli.Add(artikl);
                Session["Artikli"] = artikli;

            }
            else
            {
                artikli = (List<Artikl>)Session["Artikli"];
                artikli.Add(artikl);
                Session["Artikli"] = artikli;
            }

            return View(artikli);
        }
    }
}