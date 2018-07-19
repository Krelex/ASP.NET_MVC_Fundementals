using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekt_4_1_vj.Controllers
{
    public class TocanOdgovorController : Controller
    {
        // GET: TocanOdgovor
        public ActionResult ProvjeriOdgovor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProvjeriOdgovor(string odgovor)
        {
            bool tocnost;
            if (odgovor == "crveni")
            {
                tocnost = true;
            }else
            {
                tocnost = false;
            }
            return View(tocnost);
        }
    }
}