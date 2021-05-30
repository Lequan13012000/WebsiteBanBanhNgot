namespace DbWebsite
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDb : DbContext
    {
        public MyDb()
            : base("name=MyDb")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<bill_detail> bill_detail { get; set; }
        public virtual DbSet<bill> bills { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<news> news { get; set; }
        public virtual DbSet<products> products { get; set; }
        public virtual DbSet<slide> slides { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<type_products> type_products { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<new_products> new_products { get; set; }
        public virtual DbSet<pro_products> pro_products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<bill_detail>()
                .Property(e => e.updated_at)
                .IsFixedLength();

            modelBuilder.Entity<bill>()
                .Property(e => e.payment)
                .IsUnicode(false);

            modelBuilder.Entity<bill>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<bill>()
                .Property(e => e.updated_at)
                .IsFixedLength();

            modelBuilder.Entity<bill>()
                .HasMany(e => e.bill_detail)
                .WithRequired(e => e.bill)
                .HasForeignKey(e => e.id_bill)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.name_cus)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.address_cus)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.updated_at)
                .IsFixedLength();

            modelBuilder.Entity<customer>()
                .HasMany(e => e.bills)
                .WithOptional(e => e.customer)
                .HasForeignKey(e => e.id_customer);

            modelBuilder.Entity<news>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<news>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<news>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<news>()
                .Property(e => e.update_at)
                .IsFixedLength();

            modelBuilder.Entity<products>()
                .Property(e => e.images)
                .IsUnicode(false);

            modelBuilder.Entity<products>()
                .Property(e => e.unit)
                .IsUnicode(false);

            modelBuilder.Entity<products>()
                .HasMany(e => e.bill_detail)
                .WithRequired(e => e.product)
                .HasForeignKey(e => e.id_product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<slide>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<slide>()
                .Property(e => e.image_sl)
                .IsUnicode(false);

            modelBuilder.Entity<type_products>()
                .Property(e => e.images)
                .IsUnicode(false);

            modelBuilder.Entity<type_products>()
                .HasMany(e => e.products)
                .WithOptional(e => e.type_products)
                .HasForeignKey(e => e.id_type);

            modelBuilder.Entity<user>()
                .Property(e => e.full_name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password_us)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.address_us)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.remember_token)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.updated_at)
                .IsFixedLength();

            modelBuilder.Entity<new_products>()
                .Property(e => e.images)
                .IsUnicode(false);

            modelBuilder.Entity<new_products>()
                .Property(e => e.unit)
                .IsUnicode(false);

            modelBuilder.Entity<pro_products>()
                .Property(e => e.images)
                .IsUnicode(false);

            modelBuilder.Entity<pro_products>()
                .Property(e => e.unit)
                .IsUnicode(false);
        }
    }
}
