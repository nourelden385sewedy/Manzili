using Manzili.Models;
using Microsoft.EntityFrameworkCore;

namespace Manzili
{
    public class ManziliDbContext : DbContext
    {
        public ManziliDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cascade delete for Addresses when User is deleted
            modelBuilder.Entity<Address>()
                .HasOne(a => a.User)
                .WithMany(u => u.Addresses)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Timestamps auto-update on changes
            modelBuilder.Entity<User>()
                .Property(u => u.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<Address>()
                .Property(a => a.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
