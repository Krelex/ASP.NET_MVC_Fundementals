using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekt_11_1_vj.Controllers
{
    public class DijeljenjeController : Controller
    {
        // GET: Dijeljenje
        public ActionResult Dijeli(decimal brojA , decimal brojB)
        {
            try
            {
                decimal rezulat = brojA / brojB;
                ViewBag.Rezultat = rezulat;
                return View();

            }
            catch (Exception ex)
            {
                ViewBag.Rezultat = ex.Message;
                return View();
            }
        }
    }
}