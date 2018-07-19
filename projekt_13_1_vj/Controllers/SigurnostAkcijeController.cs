using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekt_13_1_vj.Controllers
{
    public class SigurnostAkcijeController : Controller
    {
        [Authorize]
        public ActionResult ZasticenaAkcija()
        {
            return View();
        }

        
        public ActionResult NeZasticenaAkcija()
        {
            return View();
        }
    }
}