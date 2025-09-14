using Microsoft.EntityFrameworkCore;

namespace Manzili.Models
{
    public class ManziliDbContext : DbContext
    {
        public ManziliDbContext(DbContextOptions<ManziliDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // -------------------------
            // Indexes
            // -------------------------
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Optional unique code for Discount
            modelBuilder.Entity<Discount>()
                .HasIndex(d => d.Code)
                .IsUnique();

            // -------------------------
            // Enum conversions (store enums as strings)
            // -------------------------
            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<string>();

            modelBuilder.Entity<Service>()
                .Property(s => s.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Order>()
                .Property(o => o.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Payment>()
                .Property(p => p.PaymentMethod)
                .HasConversion<string>();

            modelBuilder.Entity<Payment>()
                .Property(p => p.Status)
                .HasConversion<string>();

            // -------------------------
            // Relationships & Delete Behavior
            // -------------------------

            // User -> Services
            modelBuilder.Entity<User>()
                .HasMany(u => u.Services)
                .WithOne(s => s.Provider)
                .HasForeignKey(s => s.ProviderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Service -> ServiceImages
            modelBuilder.Entity<Service>()
                .HasMany(s => s.Images)
                .WithOne(si => si.Service)
                .HasForeignKey(si => si.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            // Service -> Discounts
            modelBuilder.Entity<Service>()
                .HasMany(s => s.Discounts)
                .WithOne(d => d.Service)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            // Service -> OrderServices (cascade delete order items, keep orders)
            modelBuilder.Entity<Service>()
                .HasMany(s => s.OrderServices)
                .WithOne(os => os.Service)
                .HasForeignKey(os => os.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            // Order -> OrderServices
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderServices)
                .WithOne(os => os.Order)
                .HasForeignKey(os => os.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // User (Buyer) -> Orders
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.Buyer)
                .HasForeignKey(o => o.BuyerId)
                .OnDelete(DeleteBehavior.Cascade);

            // User -> Reviews
            modelBuilder.Entity<User>()
                .HasMany(u => u.Reviews)
                .WithOne(r => r.Reviewer)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // User -> Notifications
            modelBuilder.Entity<User>()
                .HasMany(u => u.Notifications)
                .WithOne(n => n.User)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // User -> Addresses
            modelBuilder.Entity<User>()
                .HasMany(u => u.Addresses)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Discount -> DiscountUsage
            modelBuilder.Entity<Discount>()
                .HasMany(d => d.UsageHistory)
                .WithOne(u => u.Discount)
                .HasForeignKey(u => u.DiscountId)
                .OnDelete(DeleteBehavior.Cascade);

            // Payment <-> Order (strict 1:1, cascade delete payment if order deleted)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Payment)
                .WithOne(p => p.Order)
                .HasForeignKey<Payment>(p => p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Payment -> User (if user deleted, their payments also deleted)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Payments)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // OrderService -> Provider (denormalized ProviderId, restrict delete)
            modelBuilder.Entity<OrderService>()
                .HasOne(os => os.Service)
                .WithMany()
                .HasForeignKey(os => os.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceImage> ServiceImages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderService> OrderServices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DiscountUsage> DiscountUsages { get; set; }
    }
}
