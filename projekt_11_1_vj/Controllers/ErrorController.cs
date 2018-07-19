using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekt_11_1_vj.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(string errorMessage)
        {
            @ViewBag.Error = errorMessage;

            return View();
        }

        public ActionResult Global()
        {
            return View();
        }
    }
}