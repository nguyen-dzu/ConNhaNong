using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ConNhaNong.Models
{
    public partial class Model : DbContext
    {
        public Model()
            : base("name=Model")
        {
        }

        public virtual DbSet<product> products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<product>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.file_names)
                .IsUnicode(false);
        }
    }
}
