using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekt_4_1_vj.Controllers
{
    public class BrojGodinaController : Controller
    {
        // GET: BrojGodina
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Racunaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Racunaj(DateTime? datum)
        {

            TimeSpan? total = DateTime.Now - datum;
            return View(total);
        }
    }
}