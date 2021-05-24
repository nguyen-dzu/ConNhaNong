using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ConNhaNong.Models
{
    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<product> products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<product>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.name_product)
                .IsUnicode(false);
        }
    }
}
