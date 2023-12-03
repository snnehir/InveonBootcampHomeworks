﻿// <auto-generated />
using Inveon.Services.FavoriteAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inveon.Services.FavoriteAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231201211340_InitFavoriteDb")]
    partial class InitFavoriteDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Inveon.Services.FavoriteAPI.Models.FavoriteProduct", b =>
                {
                    b.Property<int>("FavoriteProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FavoriteProductId"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FavoriteProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("FavoriteProducts");
                });

            modelBuilder.Entity("Inveon.Services.FavoriteAPI.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Inveon.Services.FavoriteAPI.Models.FavoriteProduct", b =>
                {
                    b.HasOne("Inveon.Services.FavoriteAPI.Models.Product", "Product")
                        .WithMany("FavoriteProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Inveon.Services.FavoriteAPI.Models.Product", b =>
                {
                    b.Navigation("FavoriteProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
