using projekt_8_3_vj.Models;
using projekt_8_3_vj.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekt_8_3_vj.Controllers
{
    public class TecajController : Controller
    {
        Repozitorij repo = new Repozitorij();

        // GET: Tecaj
        public ActionResult List()
        {
            List<TecajModel> lista = new List<TecajModel>();
            lista = repo.GetTecaje();

            return View(lista);
        } 

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TecajModel tecaj)
        {
            repo.KreirajTecaj(tecaj);

            return RedirectToAction("List");
        }

        public ActionResult Details(int id)
        {
            int ID = int.Parse(Request.QueryString["id"]);

            TecajModel tecaj = repo.GetTecaj(ID);

            return View(tecaj);
        }

        public ActionResult Edit()
        {
            int ID = int.Parse(Request.QueryString["id"]);

            TecajModel tecaj = repo.GetTecaj(ID);

            return View(tecaj);
        }

        [HttpPost]
        public ActionResult Edit(TecajModel tecaj)
        {
            repo.UrediTecaj(tecaj);

            return RedirectToAction("List");
        }

        public ActionResult Delete()
        {
            int ID = int.Parse(Request.QueryString["id"]);
            
            bool check = repo.IzbrisiTecaj(ID);

            if (check)
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