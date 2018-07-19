using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projekt_5_4_vj.Models
{
    public class Artikli
    {
        public string Kategorija { get; set; }
        public string Naziv { get; set; }
        public decimal Cijena { get; set; }
        public decimal Kolicina { get; set; }


        public string Ukupno()
        {
            return (this.Cijena * this.Kolicina).ToString();
        }
    }
}