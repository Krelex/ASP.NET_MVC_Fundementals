using projekt_8_3_vj.Models;
using projekt_8_3_vj.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace projekt_8_3_vj.Controllers
{
    public class PolaznikController : Controller
    {
        Repozitorij repo = new Repozitorij();

        public ActionResult List()
        {
            List<PolaznikModel> lista = new List<PolaznikModel>();
            lista = repo.GetPolaznike();

            return View(lista);
        }

        public ActionResult Create()
        {
            PolaznikModel polaznik = new PolaznikModel(true);
            List<GradModel> gradovi = polaznik.lstGradovi;
            ViewBag.Gradovi = gradovi;

            return View();
        }

        [HttpPost]
        public ActionResult Create(PolaznikModel polaznik)
        {
            repo.KreirajPolaznika(polaznik);

            return RedirectToAction("List");
        }

        public ActionResult Details()
        {
            int id = int.Parse(Request.QueryString["id"]);
            PolaznikModel polaznik = repo.GetPolaznik(id);
            return View(polaznik);
        }

        public ActionResult Edit()
        {
            PolaznikModel polaznik = new PolaznikModel(true);
            List<GradModel> gradovi = polaznik.lstGradovi;
            ViewBag.Gradovi = gradovi;

            int id = int.Parse(Request.QueryString["id"]);
            PolaznikModel polaznik2 = repo.GetPolaznik(id);

            return View(polaznik2);
        }

        [HttpPost]
        public ActionResult Edit(PolaznikModel polaznik)
        {
            repo.UrediPolaznika(polaznik);
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            int ID = int.Parse(Request.QueryString["id"]);
            bool obrisan = repo.IzbrisiPolaznika(ID);

            if (obrisan)
            {
                return RedirectToAction("List");
            }
            else
            {
                return View("DelError");
            }
        }
    }
}