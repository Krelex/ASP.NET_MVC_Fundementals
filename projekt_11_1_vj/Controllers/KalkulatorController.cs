using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekt_11_1_vj.Controllers
{
    public class KalkulatorController : Controller
    {
        char[] operacije = { '+', '-', '/', '*' };

        // GET: Kalkulator
        public ActionResult Index()
        {
            ViewBag.op = operacije;

            return View();
        }

        [HttpPost]
        [HandleError]
        public ActionResult Index(decimal brojA , decimal brojB , char operacija)
        {
           
                decimal rezultat;

                switch (operacija)
                {
                    case '+':
                        rezultat = brojA + brojB;
                        break;
                    case '-':
                        rezultat = brojA - brojB;
                        break;
                    case '*':
                        rezultat = brojA * brojB;
                        break;
                    case '/':
                        rezultat = brojA / brojB;
                        break;
                    default:
                        throw new ArgumentException("Unjeli ste krivu operaciju!");
                }

                ViewBag.op = operacije;

                ViewBag.Rez = rezultat; 

                return View();
            
        }
    }
}