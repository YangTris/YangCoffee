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
    public class ApplicationDbContext : IdentityDbContext<User>
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
        public DbSet<ProductRating> ProductRatings { get; set; }

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

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = adminId,
                    UserName = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new User
                {
                    Id = userId,
                    UserName = "user@gmail.com",
                    NormalizedUserName = "USER@GMAIL.COM",
                    Email = "user@gmail.com",
                    NormalizedEmail = "USER@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                    SecurityStamp = Guid.NewGuid().ToString()
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
                    CategoryId = "00000000000000000000000001",
                    Name = "Espresso",
                    Description = "Various types of coffee beans."
                },
                new Category
                {
                    CategoryId = "00000000000000000000000002",
                    Name = "Blends",
                    Description = "Mixing flavor of many type of coffee"
                },
                new Category
                {
                    CategoryId = "00000000000000000000000003",
                    Name = "Single Origins",
                    Description = "Different varieties of tea."
                },
                new Category
                {
                    CategoryId = "00000000000000000000000004",
                    Name = "Decaf",
                    Description = "Coffee and tea accessories."
                }
            );

            // Seed data for Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = "10000000000000000000000000",
                    Name = "House Espresso",
                    Description = "No competition here: This much-awarded espresso blend puts its " +
                    "game face on in the form of semi-sweet, zesty, full-body flavored. Plays well with milk.",
                    BasePrice = 15.99m,
                    CreatedDate = DateTimeOffset.UtcNow,
                    UpdatedDate = DateTimeOffset.UtcNow,
                    CategoryId = "00000000000000000000000001"
                },
                new Product
                {
                    ProductId = "20000000000000000000000000",
                    Name = "Space Cadet",
                    Description = "Extra smooth, extra chocolaty-sweet, and dare we say...extraterrestrial? " +
                    "A splash of ripe cherry juiciness makes this crowd-pleasing cup every bit as delicious hot as it is cold.",
                    BasePrice = 9.99m,
                    CreatedDate = DateTimeOffset.UtcNow,
                    UpdatedDate = DateTimeOffset.UtcNow,
                    CategoryId = "00000000000000000000000002"
                },
                new Product
                {
                    ProductId = "30000000000000000000000000",
                    Name = "Space Cowboy",
                    Description = "Blast off with this delightfully soft and fruity coffee sourced from Mrs. " +
                    "Tigest Wako's small farm in the famous Yirgacheffe region of Ethiopia.",
                    BasePrice = 25.99m,
                    CreatedDate = DateTimeOffset.UtcNow,
                    UpdatedDate = DateTimeOffset.UtcNow,
                    CategoryId = "00000000000000000000000003"
                },
                new Product
                {
                    ProductId = "40000000000000000000000000",
                    Name = "Decaf Fool's Gold",
                    Description = "This decaf is heavy on chocolate flavor with a " +
                    "little fruity complexity in there as well; you won't feel like a fool drinking it.",
                    BasePrice = 25.99m,
                    CreatedDate = DateTimeOffset.UtcNow,
                    UpdatedDate = DateTimeOffset.UtcNow,
                    CategoryId = "00000000000000000000000004"
                }
            );

            // Seed ProductVariants
            modelBuilder.Entity<ProductVariant>().HasData(
                new ProductVariant
                {
                    ProductVariantId = "00000000000000000000000001",
                    ProductId = "10000000000000000000000000",
                    Size = Size.Standard,
                    Region = Region.Africa,
                    RoastType = RoastType.Light,
                    Taste = "Syrupy & Smooth",
                    Price = 20.99m
                },
                new ProductVariant
                {
                    ProductVariantId = "00000000000000000000000002",
                    ProductId = "20000000000000000000000000",
                    Size = Size.Big,
                    Region = Region.Africa,
                    RoastType = RoastType.Light,
                    Taste = "Syrupy & Smooth",
                    Price = 25.99m
                },
                new ProductVariant
                {
                    ProductVariantId = "00000000000000000000000003",
                    ProductId = "30000000000000000000000000",
                    Size = Size.Small,
                    Region = Region.Africa,
                    RoastType = RoastType.Light,
                    Taste = "Syrupy & Smooth",
                    Price = 15.99m
                },
                new ProductVariant
                {
                    ProductVariantId = "00000000000000000000000004",
                    ProductId = "40000000000000000000000000",
                    Size = Size.Small,
                    Region = Region.SouthAmerica,
                    RoastType = RoastType.Medium,
                    Taste = "Sweet & Smooth",
                    Price = 15.99m
                },
                new ProductVariant
                {
                    ProductVariantId = "00000000000000000000000005",
                    ProductId = "10000000000000000000000000",
                    Size = Size.Standard,
                    Region = Region.SouthAmerica,
                    RoastType = RoastType.Medium,
                    Taste = "Sweet & Smooth",
                    Price = 20.99m
                },
                new ProductVariant
                {
                    ProductVariantId = "00000000000000000000000006",
                    ProductId = "20000000000000000000000000",
                    Size = Size.Bulk,
                    Region = Region.CentralAmerica,
                    RoastType = RoastType.Dark,
                    Taste = "Funky & Fruity",
                    Price = 35.99m
                },
                new ProductVariant
                {
                    ProductVariantId = "00000000000000000000000007",
                    ProductId = "30000000000000000000000000",
                    Size = Size.Standard,
                    Region = Region.CentralAmerica,
                    RoastType = RoastType.Dark,
                    Taste = "Comforting & Rich",
                    Price = 15.99m
                }
            );

            // Seed ProductImages
            modelBuilder.Entity<ProductImage>().HasData(
                new ProductImage
                {
                    ProductImageId = Guid.NewGuid().ToString(),
                    ProductId = "10000000000000000000000000",
                    ImageUrl = "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521222472_TRD00133_HUC_Bom_Senso_V2.png"
                },
                new ProductImage
                {
                    ProductImageId = Guid.NewGuid().ToString(),
                    ProductId = "20000000000000000000000000",
                    ImageUrl = "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521209682_FamiliaPeixotoUpdated.png"
                },
                new ProductImage
                {
                    ProductImageId = Guid.NewGuid().ToString(),
                    ProductId = "30000000000000000000000000",
                    ImageUrl = "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521226038_w73vhyjhu1y3odxqvnjt.png"
                },
                new ProductImage
                {
                    ProductImageId = Guid.NewGuid().ToString(),
                    ProductId = "40000000000000000000000000",
                    ImageUrl = "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521220065_TRD00132_SPA_High_Five_Blend_Main.png"
                },
                new ProductImage
                {
                    ProductImageId = Guid.NewGuid().ToString(),
                    ProductId = "10000000000000000000000000",
                    ImageUrl = "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521229043_WONdriftlessupdated_eda49ff4-e067-4393-9515-ef748e528bb6.png"
                },
                new ProductImage
                {
                    ProductImageId = Guid.NewGuid().ToString(),
                    ProductId = "20000000000000000000000000",
                    ImageUrl = "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521212425_sighjyhliefukn8dygvd.png"
                },
                new ProductImage
                {
                    ProductImageId = Guid.NewGuid().ToString(),
                    ProductId = "30000000000000000000000000",
                    ImageUrl = "https://xloiupwymptihhsefzqw.supabase.co/storage/v1/object/public/product-images/1746521212425_sighjyhliefukn8dygvd.png"
                }
            );

            modelBuilder.Entity<ProductRating>()
                .HasIndex(r => new { r.UserId, r.ProductId })
                .IsUnique();
        }
    }
}
