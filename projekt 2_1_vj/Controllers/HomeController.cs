using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekt_2_1_vj.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string model= "Rezulatat operacije 4 + 3 * 3 =";

            return View((object)model);
        }
    }
}