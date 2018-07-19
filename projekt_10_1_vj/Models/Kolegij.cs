namespace projekt_10_1_vj.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Kolegij
    {
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
