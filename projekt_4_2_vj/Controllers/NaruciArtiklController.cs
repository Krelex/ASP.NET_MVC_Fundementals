using projekt_4_2_vj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekt_4_2_vj.Controllers
{
    public class NaruciArtiklController : Controller
    {
        // GET: NaruciArtikl
        public ActionResult naruci()
        {
            return View();
        }
        [HttpPost]
        public ActionResult naruci(Artikl artikl)
        {
            if (artikl.Kolicina > 10)
            {
                ViewBag.kolicina = "Trazena kolicna nije dopsutpna na skladistu! :( ";
                return View("naruci");
            }
            else
            {
                return View("prikazi", artikl);
            }
        }
    }
}