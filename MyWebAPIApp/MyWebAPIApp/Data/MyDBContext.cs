using Microsoft.EntityFrameworkCore;

namespace MyWebAPIApp.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Order> orders { get; set; }    
        public DbSet<OrderDetail> ordersDetails { get; set; }
        public DbSet<Account> accounts { get; set; }    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey(o => o.OrderId);
                e.Property(o => o.CreateTime).HasDefaultValueSql("getutcDate()");
                e.Property(o => o.CustomerName).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<OrderDetail>(e =>
            {
                e.ToTable("OrderDetail");
                e.HasKey(o => new { o.OrderId, o.ProductId });

                e.HasOne(o => o.Orders)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(o => o.OrderId)
                .HasConstraintName("FK_OrderDetail_Order");

                e.HasOne(o => o.Products)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(o => o.ProductId)
                .HasConstraintName("FK_OrderDetail_Product");
            });
            modelBuilder.Entity<Account>(e =>
            {
                e.HasIndex(e => e.usename).IsUnique();
                e.Property(e => e.fullName).IsRequired().HasMaxLength(150);
                e.Property(e => e.email).IsRequired().HasMaxLength(150);
            });
        }
    }
}
