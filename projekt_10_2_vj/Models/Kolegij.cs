using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projekt_10_2_vj.Models
{
    public class Kolegij
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Ucionica { get; set; }
        public DateTime DatumPocetka { get; set; }

    }
}