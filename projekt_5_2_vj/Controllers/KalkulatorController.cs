using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekt_5_2_vj.Controllers
{
    public class KalkulatorController : Controller
    {
        [HttpGet]
        public ActionResult Izracunaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Izracunaj(int? prvi , int? drugi , string operacija)
        {
            try
            {
                if (prvi == null || drugi == null)
                {
                    throw new Exception("Niste unjeli ispravana parametar!");
                }
                ViewBag.prvi = prvi;
                ViewBag.drugi = drugi;

                string model = operacija;
                return View((object)model);
            }
            catch (Exception ex)
            {

                ViewBag.error = ex.Message;
                return View();
            }

        }
    }
}