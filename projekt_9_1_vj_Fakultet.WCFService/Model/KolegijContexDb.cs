using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace projekt_9_1_vj_Fakultet.WCFService.Model
{
    public class KolegijContexDb : DbContext
    {
        public KolegijContexDb()
            :base("name=FakultetBaza")
        {
        }

        public DbSet<Models.Kolegij> Kolegiji { get; set; }
            
    }
}