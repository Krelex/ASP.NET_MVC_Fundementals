using projekt_9_1_vj_Fakultet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekt_9_1_vj_Fakultet.Controllers
{
    public class KolegijWSController : Controller
    {
        KolegijService.Service1Client client = new KolegijService.Service1Client();
        
        // GET: KolegijWS
        public ActionResult Index()
        {
            var lista = client.GetAll().ToList();
            return View(lista);
        }

        public ActionResult GetBy(int id)
        {
            var kolegij = client.GetData(id);
            return View(kolegij);
        }
    }
}