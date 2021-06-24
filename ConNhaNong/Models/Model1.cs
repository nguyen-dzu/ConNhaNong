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

        public virtual DbSet<Bill_new> Bill_new { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<products> products { get; set; }
        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }

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

            modelBuilder.Entity<Contact>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.NumberPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Status_contact)
                .IsUnicode(false);

            modelBuilder.Entity<Discount>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<products>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<products>()
                .Property(e => e.file_names)
                .IsUnicode(false);

            modelBuilder.Entity<products>()
                .HasMany(e => e.Report)
                .WithOptional(e => e.products)
                .HasForeignKey(e => e.id_product);

            modelBuilder.Entity<Report>()
                .Property(e => e.id_product)
                .IsUnicode(false);

            modelBuilder.Entity<Report>()
                .Property(e => e.Email_send)
                .IsUnicode(false);

            modelBuilder.Entity<Report>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<Report>()
                .Property(e => e.Status_report)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Passwords)
                .IsUnicode(false);
        }
    }
}
