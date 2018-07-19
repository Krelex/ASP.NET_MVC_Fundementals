using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekt_5_2_vj.Controllers
{
    public class RandomNumController : Controller
    {
        // GET: RandomNum
        public ActionResult Random()
        {
            Random random = new Random();

            int modelNum = random.Next(1, 1000);

            return View(modelNum);
        }
    }
}