using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var adminRoleId = Guid.NewGuid().ToString();
            var userRoleId = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = userRoleId,
                    Name = "User",
                    NormalizedName = "USER"
                }
            );

            // Seed data for Admin user
            var adminId = Guid.NewGuid().ToString();
            var userId = Guid.NewGuid().ToString();
            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = adminId,
                    UserName = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                    SecurityStamp = string.Empty
                },
                new IdentityUser
                {
                    Id = userId,
                    UserName = "user@gmail.com",
                    NormalizedUserName = "USER@GMAIL.COM",
                    Email = "user@gmail.com",
                    NormalizedEmail = "USER@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                    SecurityStamp = string.Empty
                }
            );

            // Assign Admin role to Admin user
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = adminId,
                    RoleId = adminRoleId
                },
                new IdentityUserRole<string>
                {
                    UserId = userId,
                    RoleId = userRoleId
                }
            );

            // Seed data for Categories
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = "1",
                    Name = "Espresso",
                    Description = "Various types of coffee beans."
                },
                new Category
                {
                    CategoryId = "2",
                    Name = "Blends",
                    Description = "Mixing flavor of many type of coffee"
                },
                new Category
                {
                    CategoryId = "3",
                    Name = "Single Origins",
                    Description = "Different varieties of tea."
                },
                new Category
                {
                    CategoryId = "4",
                    Name = "Cold Brew",
                    Description = "Coffee and tea accessories."
                }
            );

            // Seed data for Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = "780905a8-1505-4635-a3ed-2872625bd071",
                    Name = "House Espresso",
                    Description = "Rich and aromatic Ethiopian coffee beans.",
                    BasePrice = 15.99m,
                    CreatedDate = DateTimeOffset.UtcNow,
                    UpdatedDate = DateTimeOffset.UtcNow,
                    CategoryId = "1"
                },
                new Product
                {
                    ProductId = "1ec624d5-25d0-4a5c-9d47-925be2439e70",
                    Name = "Space Cadet",
                    Description = "Refreshing and healthy green tea.",
                    BasePrice = 9.99m,
                    CreatedDate = DateTimeOffset.UtcNow,
                    UpdatedDate = DateTimeOffset.UtcNow,
                    CategoryId = "2"
                },
                new Product
                {
                    ProductId = "1e38e0e9-e76b-462a-9141-13637859449c",
                    Name = "Space Cowboy",
                    Description = "High-quality French press for coffee brewing.",
                    BasePrice = 25.99m,
                    CreatedDate = DateTimeOffset.UtcNow,
                    UpdatedDate = DateTimeOffset.UtcNow,
                    CategoryId = "3"
                }
            );

            // Seed ProductVariants
            modelBuilder.Entity<ProductVariant>().HasData(
                new ProductVariant
                {
                    ProductVariantId = Guid.NewGuid().ToString(),
                    ProductId = "780905a8-1505-4635-a3ed-2872625bd071",
                    Size = Size.Standard,
                    Region = Region.Africa,
                    RoastType = RoastType.Light,
                    Taste = "Syrupy & Smooth",
                    Price = 15.99m
                },
                new ProductVariant
                {
                    ProductVariantId = Guid.NewGuid().ToString(),
                    ProductId = "1ec624d5-25d0-4a5c-9d47-925be2439e70",
                    Size = Size.Small,
                    Region = Region.SouthAmerica,
                    RoastType = RoastType.Light,
                    Taste = "Sweet & Smooth",
                    Price = 15.99m
                },
                new ProductVariant
                {
                    ProductVariantId = Guid.NewGuid().ToString(),
                    ProductId = "1e38e0e9-e76b-462a-9141-13637859449c",
                    Size = Size.Bulk,
                    Region = Region.CentralAmerica,
                    RoastType = RoastType.Dark,
                    Taste = "Funky & Fruity",
                    Price = 15.99m
                }
            );

            // Seed ProductImages
            modelBuilder.Entity<ProductImage>().HasData(
                new ProductImage
                {
                    ProductImageId = Guid.NewGuid().ToString(),
                    ProductId = "780905a8-1505-4635-a3ed-2872625bd071",
                    ImageUrl = "images/House Espresso1.jpg"
                },
                new ProductImage
                {
                    ProductImageId = Guid.NewGuid().ToString(),
                    ProductId = "780905a8-1505-4635-a3ed-2872625bd071",
                    ImageUrl = "images/House Espresso2.jpg"
                },
                new ProductImage
                {
                    ProductImageId = Guid.NewGuid().ToString(),
                    ProductId = "1ec624d5-25d0-4a5c-9d47-925be2439e70",
                    ImageUrl = "images/Space Cadet_1.jpg"
                },
                new ProductImage
                {
                    ProductImageId = Guid.NewGuid().ToString(),
                    ProductId = "1ec624d5-25d0-4a5c-9d47-925be2439e70",
                    ImageUrl = "images/Space Cadet_2.jpg"
                },
                new ProductImage
                {
                    ProductImageId = Guid.NewGuid().ToString(),
                    ProductId = "1e38e0e9-e76b-462a-9141-13637859449c",
                    ImageUrl = "images/Space Cowboy1.jpg"
                }
            );
        }
    }
}
