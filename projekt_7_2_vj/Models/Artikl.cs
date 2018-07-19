using projekt_7_2_vj.Models.Validacije;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace projekt_7_2_vj.Models
{
    [modelValidation(ErrorMessage = "Cijena nesmije biti veca od 1000, posto ste unjeli vise od 300 atrikla!!!")]
    public class Artikl
    {
        [Required(ErrorMessage ="Molimo vas unesite Kategoriju!")]
        public string Kategorija { get; set; }

        [Required(ErrorMessage = "Molimo vas unesite Naziv!")]
        [StringLength(30, ErrorMessage = "Naziv mora sadrzavati izmedu 3 i 30 znakova!", MinimumLength = 3) ]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Molimo vas unesite Cijenu!")]
        public decimal Cijena { get; set; }

        [Required(ErrorMessage = "Molimo vas unesite Kolicinu!")]
        [Range(1,1000, ErrorMessage = "Kolicina moze biti izmedu 1 i 1000!")]
        public decimal Kolicina { get; set; }

    }
}