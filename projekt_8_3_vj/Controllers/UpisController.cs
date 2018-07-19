using projekt_8_3_vj.Models;
using projekt_8_3_vj.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekt_8_3_vj.Controllers
{
    public class UpisController : Controller
    {
        // GET: Upis
        public ActionResult Unos()
        {
            PolaznikModel polaznik = new PolaznikModel(true);
            List<GradModel> gradovi = polaznik.lstGradovi;

            ViewBag.Gradovi = gradovi;

            Repozitorij repo = new Repozitorij();
            List<TecajModel> tecajevi = repo.GetTecaje();

            ViewBag.Tecaji = tecajevi;

            return View();
        }

        [HttpPost]
        public ActionResult Unos(UpisModel upis , PolaznikModel polaznik)
        {
            Repozitorij repo = new Repozitorij();

            int id = repo.KreirajPolaznika(polaznik);

            upis.DatumUpisa = DateTime.Now;
            upis.IdPolaznik = id;

            repo.KreirajUpis(upis);

            return RedirectToAction("Unos");
        }
    }
}