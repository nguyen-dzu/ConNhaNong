using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ConNhaNong.Models
{
    public partial class Model3 : DbContext
    {
        public Model3()
            : base("name=Model3")
        {
        }

        public virtual DbSet<product> products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<product>()
                .Property(e => e.ID)
                .IsUnicode(false);
        }
    }
}
