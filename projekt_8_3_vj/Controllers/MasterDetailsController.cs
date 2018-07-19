using projekt_8_3_vj.Models;
using projekt_8_3_vj.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekt_8_3_vj.Controllers
{
    public class MasterDetailsController : Controller
    {
        Repozitorij repo = new Repozitorij();
        
        // GET: MasterDetails
        public ActionResult MasterDetails()
        {
            List<UpisDetailModel> master = repo.GetDetailMaster();

            return View(master);
        }
    }
}