using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace projekt_9_1_vj_Fakultet.Models
{
    [DataContract]
    public class Kolegij
    {

        [Key]
        [Required]
        [DataMember]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [DataMember]
        public string Naziv { get; set; }

        [Required]
        [StringLength(500)]
        [DataMember]
        public string Opis { get; set; }

        [Required]
        [StringLength(20)]
        [DataMember]
        public string Ucionica { get; set; }

        [DataMember]
        public DateTime DatumPocetka { get; set; }
    }
}