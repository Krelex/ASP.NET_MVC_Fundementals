using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projekt_9_1_vj_Fakultet.Models
{
    public class Kolegij
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Naziv { get; set; }

        [Required]
        [StringLength(500)]
        public string Opis { get; set; }

        [Required]
        [StringLength(20)]
        public string Ucionica { get; set; }

        public DateTime DatumPocetka { get; set; }
    }
}