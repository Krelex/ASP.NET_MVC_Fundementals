using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projekt_8_3_vj.Models
{
    public class UpisDetailModel
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime DatumUpisa { get; set; }
    }
}