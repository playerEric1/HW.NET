using ApplicationCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace EShopAPI.Data;

public class EShopDBContext : DbContext
{
    public EShopDBContext()
    {

    }
    public EShopDBContext(DbContextOptions<EShopDBContext> options) : base(options)
    {

    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<CategoryVariation> CategoryVariations { get; set; }
    public DbSet<VariationValue> VariationValues { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductVariationValue> ProductVariationValues { get; set; }
    public DbSet<Shipper> Shippers { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<ShipperRegion> ShipperRegions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships
        modelBuilder.Entity<ProductCategory>()
            .HasMany(pc => pc.Products)
            .WithOne(p => p.ProductCategory)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<ProductCategory>()
            .HasMany(pc => pc.Variations)
            .WithOne(pc => pc.Category)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<ProductCategory>()
            .HasOne(p => p.ParentCategory)
            .WithMany(p => p.SubCategories)
            .HasForeignKey(p => p.ParentCategoryId);

        modelBuilder.Entity<CategoryVariation>()
            .HasMany(cv => cv.VariationValues)
            .WithOne(vv => vv.CategoryVariation)
            .HasForeignKey(vv => vv.CategoryId);

        modelBuilder.Entity<ProductVariationValue>()
            .HasKey(pvv => new { pvv.ProductId, pvv.VariationValueId });

        modelBuilder.Entity<ProductVariationValue>()
            .HasOne(pvv => pvv.Product)
            .WithMany(p => p.ProductVariationValues)
            .HasForeignKey(pvv => pvv.ProductId);

        modelBuilder.Entity<ProductVariationValue>()
            .HasOne(pvv => pvv.VariationValue)
            .WithMany(vv => vv.ProductVariationValues)
            .HasForeignKey(pvv => pvv.VariationValueId);

        modelBuilder.Entity<ShipperRegion>()
            .HasKey(sr => new { sr.RegionId, sr.ShipperId });

        modelBuilder.Entity<ShipperRegion>()
            .HasOne(sr => sr.Region)
            .WithMany(r => r.ShipperRegions)
            .HasForeignKey(sr => sr.RegionId);

        modelBuilder.Entity<ShipperRegion>()
            .HasOne(sr => sr.Shipper)
            .WithMany(s => s.ShipperRegions)
            .HasForeignKey(sr => sr.ShipperId);
    }
}