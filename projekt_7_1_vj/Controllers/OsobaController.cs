using projekt_7_1_vj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekt_7_1_vj.Controllers
{
    public class OsobaController : Controller
    {
        public ActionResult UnesiOsobu()
        {
            return View();
        }

        public ActionResult ProvjeriOsobu(Osoba osoba)
        {
            if (string.IsNullOrWhiteSpace(osoba.Ime))
            {
                ModelState.AddModelError("Ime", "Ime je obavezno!");
            }

            if (string.IsNullOrWhiteSpace(osoba.Prezime))
            {
                ModelState.AddModelError("Prezime", "Prezime je obavezno!");
            }
            
            if (ModelState.IsValid)
            {
                return View(osoba);
            }
            else
            {
                return View("UnesiOsobu");
            }
        }
    }
}