using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekt_11_1_vj.Controllers
{
    public class ZbrojController : Controller
    {
        public ActionResult Zbroj()
        {
            return View();
        }

        [HttpPost]
        [HandleError]
        public ActionResult Zbroj(decimal brojA , decimal brojB)
        {
            ViewBag.Rez = brojA + brojB;

            return View();
        }
    }
}