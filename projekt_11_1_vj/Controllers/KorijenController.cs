using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekt_11_1_vj.Controllers
{
    public class KorijenController : Controller
    {
        // GET: Korijen
        public ActionResult Korijen()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Korijen(decimal broj)
        {
            
            double rezuultat = Math.Sqrt( Convert.ToDouble(broj));
            ViewBag.Rezultat = rezuultat;
            return View();
        }

        protected override void OnException(ExceptionContext filter)
        {
            Exception ex = filter.Exception;

            filter.ExceptionHandled = true;

            var model = new HandleErrorInfo(ex, "controller", "action");

            filter.Result = new ViewResult()
            {
                ViewName = "ErrorMessage",
                ViewData = new ViewDataDictionary(model)
            };
        }
    }
}