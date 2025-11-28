using Manzili.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Manzili.Data
{
    public class ManziliDbContext : DbContext
    {
        public ManziliDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var hasher = new PasswordHasher<User>();

            // Cascade delete for Addresses when User is deleted
            modelBuilder.Entity<Address>()
                .HasOne(a => a.User)
                .WithMany(u => u.Addresses)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Timestamps auto-update on changes
            //modelBuilder.Entity<User>()
            //    .Property(u => u.UpdatedAt)
            //    .ValueGeneratedOnAddOrUpdate();

            //modelBuilder.Entity<Address>()
            //    .Property(a => a.UpdatedAt)
            //    .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<string>();

            modelBuilder.Entity<User>().HasData(
                new
                {
                    Id = 1,
                    FullName = "Ahmed Hassan",
                    Email = "ahmed@gmail.com",
                    PhoneNumber = "01012345678",
                    PasswordHash = hasher.HashPassword(null, "hashed_password_1"),
                    Role = UserRole.Buyer,
                    IsBlocked = false,
                    CreatedAt = new DateTime(2025, 9, 26),
                    UpdatedAt = new DateTime(2025, 9, 26),
                    BlockedUntil = (DateTime?)null,
                    BlockReason = (string?)null
                },
                new
                {
                    Id = 2,
                    FullName = "Mariam Adel",
                    Email = "mariam.adel@yahoo.com",
                    PhoneNumber = "01098765432",
                    PasswordHash = hasher.HashPassword(null, "hashed_password_2"),
                    Role = UserRole.Provider,
                    IsBlocked = false,
                    CreatedAt = new DateTime(2025, 11, 6),
                    UpdatedAt = new DateTime(2025, 11, 6),
                    BlockedUntil = (DateTime?)null,
                    BlockReason = (string?)null
                },
                new
                {
                    Id = 3,
                    FullName = "Omar Khaled",
                    Email = "omarkhaled@outlook.com",
                    PhoneNumber = "01029305160",
                    PasswordHash = hasher.HashPassword(null, "hashed_password_3"),
                    Role = UserRole.Buyer,
                    IsBlocked = false,
                    CreatedAt = new DateTime(2025, 10, 25),
                    UpdatedAt = new DateTime(2025, 10, 25),
                    BlockedUntil = (DateTime?)null,
                    BlockReason = (string?)null
                },
                new
                {
                    Id = 4,
                    FullName = "Sarah Nabil",
                    Email = "sarah.nabil@gmail.com",
                    PhoneNumber = "01022223333",
                    PasswordHash = hasher.HashPassword(null, "hashed_password_4"),
                    Role = UserRole.Provider,
                    IsBlocked = false,
                    CreatedAt = new DateTime(2025, 10, 19),
                    UpdatedAt = new DateTime(2025, 10, 19),
                    BlockedUntil = (DateTime?)null,
                    BlockReason = (string?)null
                },
                new
                {
                    Id = 5,
                    FullName = "Youssef Mahmoud",
                    Email = "youssef.m@gmail.com",
                    PhoneNumber = "01044445555",
                    PasswordHash = hasher.HashPassword(null, "hashed_password_5"),
                    Role = UserRole.Provider,
                    IsBlocked = true,
                    CreatedAt = new DateTime(2025, 10, 9),
                    UpdatedAt = new DateTime(2025, 10, 9),
                    BlockedUntil = (DateTime?)null,
                    BlockReason = (string?)null
                },
                new
                {
                    Id = 6,
                    FullName = "Laila Samir",
                    Email = "laila.samir@icloud.com",
                    PhoneNumber = "01055556666",
                    PasswordHash = hasher.HashPassword(null, "hashed_password_6"),
                    Role = UserRole.Buyer,
                    IsBlocked = false,
                    CreatedAt = new DateTime(2025, 11, 3),
                    UpdatedAt = new DateTime(2025, 11, 3),
                    BlockedUntil = (DateTime?)null,
                    BlockReason = (string?)null
                }
            );


        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
