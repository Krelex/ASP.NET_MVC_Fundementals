using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekt_3_2_vj.Controllers
{
    public class GeneratorIzlazaController : Controller
    {
        // 3.2.1
        public ActionResult PopisKosarice()
        {
            return View();
        }
        
        // 3.2.2
        public ActionResult ListaArtikla()
        {
            List<string> artikli = new List<string>();
            artikli.Add("Banana");
            artikli.Add("Banana1");
            artikli.Add("Banana2");
            artikli.Add("Banana3");

            ViewBag.Artikli = artikli;
            return View();
        }

        // 3.2.3
        public RedirectToRouteResult RedirectNaMetodu(string id)
        {

            if(id == "kosarica")
            {
                return RedirectToAction("PopisKosarice");
            }else
            {
                return RedirectToAction("ListaArtikla");
            }
        }
    }
}