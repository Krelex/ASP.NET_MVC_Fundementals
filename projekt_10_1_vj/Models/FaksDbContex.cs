namespace projekt_10_1_vj.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FaksDbContex : DbContext
    {
        public FaksDbContex()
            : base("name=FaksDbContex")
        {
        }

        public virtual DbSet<Kolegij> Kolegijs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
