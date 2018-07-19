using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekt_3_1_vj.Controllers
{
    public class KontekstController : Controller
    {
        // 3.1.1
        public string Index()
        {
            return DateTime.Now.ToLongDateString();
        }

        // 3.1.2
        public string QueryPodaci( string naziv , string grad )
        {
            //string ime = Request.QueryString["ime"];
            string ime = naziv;
            // string prezime = Request.QueryString["prezime"];
            string prezime = grad;
            return ime + " " + prezime;
        }

        // 3.1.3
        public string RoutePodaci()
        {
            string kontroler = RouteData.Values["controller"].ToString();
            string akcija = RouteData.Values["action"].ToString();

            if(RouteData.Values["id"] != null)
            {
            string id = RouteData.Values["id"].ToString();
                return kontroler + " " + akcija + " " + id;
            }
            else
            {
                return kontroler + " " + akcija + " ";
            }        
        }
    }
}