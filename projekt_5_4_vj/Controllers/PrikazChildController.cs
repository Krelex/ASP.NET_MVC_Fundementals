using projekt_5_4_vj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekt_5_4_vj.Controllers
{
    public class PrikazChildController : Controller
    {
        // GET: ParcijalniPogled
        public ActionResult ObradiListu()
        {
            Artikli ar1 = new Artikli()
            {
                Kategorija = "Food",
                Naziv = "Banana",
                Cijena = 10,
                Kolicina = 10
            };
            Artikli ar2 = new Artikli()
            {
                Kategorija = "Food",
                Naziv = "Apple",
                Cijena = 20,
                Kolicina = 3
            };
            Artikli ar3 = new Artikli()
            {
                Kategorija = "Food",
                Naziv = "Hamburger",
                Cijena = 25,
                Kolicina = 1
            };
            Artikli ar4 = new Artikli()
            {
                Kategorija = "Car",
                Naziv = "Golf",
                Cijena = 1000,
                Kolicina = 2
            };

            List<Artikli> repo = new List<Artikli>() { ar1, ar2, ar3, ar4 };

            return View(repo);
        }

        public string OdrediKategoriju(Artikli artikl)
        {
            return artikl.Kategorija;
        }
    }
}