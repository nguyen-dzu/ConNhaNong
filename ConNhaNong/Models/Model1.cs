namespace ConNhaNong.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }
        //test demo
        public virtual DbSet<Bill_new> Bill_new { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill_new>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Bill_new>()
                .Property(e => e.list)
                .IsUnicode(false);

            modelBuilder.Entity<Bill_new>()
                .Property(e => e.amount)
                .IsUnicode(false);

            modelBuilder.Entity<Bill_new>()
                .Property(e => e.addresz)
                .IsUnicode(false);

            modelBuilder.Entity<Bill_new>()
                .Property(e => e.SDt)
                .IsUnicode(false);

            modelBuilder.Entity<Bill_new>()
                .Property(e => e.name_bill)
                .IsUnicode(false);

            modelBuilder.Entity<Bill_new>()
                .Property(e => e.ID_bill)
                .IsUnicode(false);

            modelBuilder.Entity<Cart>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Cart>()
                .Property(e => e.list)
                .IsUnicode(false);

            modelBuilder.Entity<Cart>()
                .Property(e => e.amount)
                .IsUnicode(false);

            modelBuilder.Entity<Cart>()
                .Property(e => e.ID_cart)
                .IsUnicode(false);

            modelBuilder.Entity<Discount>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.file_names)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Passwords)
                .IsUnicode(false);
        }
    }
}
