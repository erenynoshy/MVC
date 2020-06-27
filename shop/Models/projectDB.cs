namespace shop
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class projectDB : DbContext
    {
        public projectDB()
            : base("name=projectDB")
        {
        }

        public virtual DbSet<OrderData> OrderDatas { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderData>()
                .Property(e => e.UserID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OrderData>()
                .Property(e => e.ProductID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OrderData>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDatas)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<User>()
                .Property(e => e.userType)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.OrderDatas)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
