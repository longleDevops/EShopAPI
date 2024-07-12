using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductAPI.ApplicationCore.Entities;

namespace ProductAPI.Infrastructure.Data
{
	public class EShopDbContext:DbContext
	{
		public EShopDbContext(DbContextOptions<EShopDbContext> options):base(options)
		{
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<ProductVariationValues> ProductVariationValues { get; set; }
		public DbSet<VariationValue> VariationValues { get; set; }
        public DbSet<CategoryVariation> CategoryVariations { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Product>(ConfigureProduct);
			modelBuilder.Entity<ProductVariationValues>(ConfigureProductVariationValues);
            modelBuilder.Entity<VariationValue>(ConfigureVariationValue);
            modelBuilder.Entity<CategoryVariation>(ConfigureCategoryVariation);
            modelBuilder.Entity<ProductCategory>(ConfigureProductCategory);


        }

        private void ConfigureProduct (EntityTypeBuilder<Product> builder)
		{
			builder.ToTable("Product");
			builder.HasKey(p => p.Id);
		}

        private void ConfigureVariationValue(EntityTypeBuilder<VariationValue> builder)
        {
            builder.ToTable("VariationValue");
            builder.HasKey(v => v.Id);
        }
        private void ConfigureProductVariationValues(EntityTypeBuilder<ProductVariationValues> builder)
        {
            builder.ToTable("ProductVariationvalues");
            builder.HasKey(pv => new {pv.ProductId,pv.VariationValueId});

            

        }
        private void ConfigureCategoryVariation(EntityTypeBuilder<CategoryVariation> builder)
        {
            builder.ToTable("CatergoryVariation");
            builder.HasKey(c => c.Id);
        }

        private void ConfigureProductCategory(EntityTypeBuilder<ProductCategory> builder)
        {
	        builder.ToTable("ProductCategory");
	        builder.HasKey(c => c.Id);
        }
	}
}

