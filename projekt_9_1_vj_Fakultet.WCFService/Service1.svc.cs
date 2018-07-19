using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using projekt_9_1_vj_Fakultet.Models;
using projekt_9_1_vj_Fakultet.WCFService.Model;

namespace projekt_9_1_vj_Fakultet.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        KolegijContexDb db = new  KolegijContexDb();

        public List<Kolegij> GetAll()
        {
            return db.Kolegiji.Where(k => k.DatumPocetka > DateTime.Now).ToList();
        }

        public Kolegij GetData(int value)
        {
            return db.Kolegiji.Where(k => k.Id == value).SingleOrDefault();
        }
    }
}
