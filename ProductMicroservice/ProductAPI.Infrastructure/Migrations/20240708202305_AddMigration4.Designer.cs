﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductAPI.Infrastructure.Data;

#nullable disable

namespace ProductAPI.Infrastructure.Migrations
{
    [DbContext(typeof(EShopDbContext))]
    [Migration("20240708202305_AddMigration4")]
    partial class AddMigration4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductAPI.ApplicationCore.Entities.CategoryVariation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("CatergoryVariation", (string)null);
                });

            modelBuilder.Entity("ProductAPI.ApplicationCore.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductImg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Qty")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("ProductAPI.ApplicationCore.Entities.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("ProductCategory", (string)null);
                });

            modelBuilder.Entity("ProductAPI.ApplicationCore.Entities.ProductVariationValues", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("VariationValueId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "VariationValueId");

                    b.HasIndex("VariationValueId");

                    b.ToTable("ProductVariationvalues", (string)null);
                });

            modelBuilder.Entity("ProductAPI.ApplicationCore.Entities.VariationValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryVariationId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VariationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryVariationId");

                    b.ToTable("VariationValue", (string)null);
                });

            modelBuilder.Entity("ProductAPI.ApplicationCore.Entities.CategoryVariation", b =>
                {
                    b.HasOne("ProductAPI.ApplicationCore.Entities.ProductCategory", "ProductCategory")
                        .WithMany("CategoryVariations")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("ProductAPI.ApplicationCore.Entities.Product", b =>
                {
                    b.HasOne("ProductAPI.ApplicationCore.Entities.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("ProductAPI.ApplicationCore.Entities.ProductCategory", b =>
                {
                    b.HasOne("ProductAPI.ApplicationCore.Entities.ProductCategory", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("ProductAPI.ApplicationCore.Entities.ProductVariationValues", b =>
                {
                    b.HasOne("ProductAPI.ApplicationCore.Entities.Product", "Product")
                        .WithMany("VariationValuesOfProduct")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProductAPI.ApplicationCore.Entities.VariationValue", "VariationValue")
                        .WithMany("ProductOfVariationValues")
                        .HasForeignKey("VariationValueId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("VariationValue");
                });

            modelBuilder.Entity("ProductAPI.ApplicationCore.Entities.VariationValue", b =>
                {
                    b.HasOne("ProductAPI.ApplicationCore.Entities.CategoryVariation", "CategoryVariation")
                        .WithMany("VariationValues")
                        .HasForeignKey("CategoryVariationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryVariation");
                });

            modelBuilder.Entity("ProductAPI.ApplicationCore.Entities.CategoryVariation", b =>
                {
                    b.Navigation("VariationValues");
                });

            modelBuilder.Entity("ProductAPI.ApplicationCore.Entities.Product", b =>
                {
                    b.Navigation("VariationValuesOfProduct");
                });

            modelBuilder.Entity("ProductAPI.ApplicationCore.Entities.ProductCategory", b =>
                {
                    b.Navigation("CategoryVariations");

                    b.Navigation("ChildCategories");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("ProductAPI.ApplicationCore.Entities.VariationValue", b =>
                {
                    b.Navigation("ProductOfVariationValues");
                });
#pragma warning restore 612, 618
        }
    }
}
