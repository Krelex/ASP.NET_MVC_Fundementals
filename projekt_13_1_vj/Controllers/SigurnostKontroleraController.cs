using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekt_13_1_vj.Controllers
{
    [Authorize]
    public class SigurnostKontroleraController : Controller
    {
        // GET: SigurnostKontrolera
        public ActionResult Index()
        {
            return View();
        }
    }
}