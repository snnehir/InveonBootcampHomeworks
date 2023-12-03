﻿// <auto-generated />
using Inveon.Services.ProductAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inveon.Services.ProductAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231201163706_InitProductDb")]
    partial class InitProductDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Inveon.Services.ProductAPI.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Çorbalar"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Salatalar"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Kebaplar"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Tatlılar"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "İçecekler"
                        });
                });

            modelBuilder.Entity("Inveon.Services.ProductAPI.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

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

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                            ImageUrl = "https://i.lezzet.com.tr/images-xxlarge-recipe/domatesli-mercimek-corbasi-4193b719-eb6c-4d84-ac5a-0950329023d6.jpg",
                            Name = "Mercimek Çorbası",
                            Price = 20.0
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1,
                            Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                            ImageUrl = "https://m.media-amazon.com/images/I/81T9e8e8wJL._AC_UF1000,1000_QL80_.jpg",
                            Name = "Yayla Çorbası",
                            Price = 25.0
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 1,
                            Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                            ImageUrl = "https://www.mirzausta.com/wp-content/uploads/2021/01/kelle-paca-corbasi.jpg",
                            Name = "Kelle Paça Çorbası",
                            Price = 25.0
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 2,
                            Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                            ImageUrl = "https://www.tasocakfirin.com/image/cache/catalog/products_2021/Akdeniz-Salata-1000x1000.jpg",
                            Name = "Akdeniz Salata",
                            Price = 15.0
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 2,
                            Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                            ImageUrl = "https://www.diyetkolik.com/site_media/media/nutrition_images/44_Ton_Balkl_Gemici_Salatas.jpg",
                            Name = "Ton Balıklı Salata",
                            Price = 18.0
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 3,
                            Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                            ImageUrl = "https://www.cankebap.com.tr/wp-content/uploads/2023/07/adana-kebab-can-kebap.jpg",
                            Name = "Adana Kebap",
                            Price = 60.0
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 3,
                            Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                            ImageUrl = "https://static.ticimax.cloud/44658/uploads/urunresimleri/buyuk/tavuk-sis--53-83c.jpg",
                            Name = "Tavuk Şiş Kebap",
                            Price = 54.0
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryId = 3,
                            Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                            ImageUrl = "https://www.gozdekebap.com/wp-content/uploads/2020/04/sirinevler-kuzu-sis.jpg",
                            Name = "Kuzu Şiş Kebap",
                            Price = 70.0
                        },
                        new
                        {
                            ProductId = 9,
                            CategoryId = 3,
                            Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                            ImageUrl = "https://www.diyetkolik.com/site_media/media/foodrecipe_images/ufra-kabap.png",
                            Name = "Urfa Kebap",
                            Price = 60.0
                        },
                        new
                        {
                            ProductId = 10,
                            CategoryId = 4,
                            Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                            ImageUrl = "https://media-cdn.tripadvisor.com/media/photo-s/13/59/46/a7/photo0jpg.jpg",
                            Name = "Künefe",
                            Price = 30.0
                        },
                        new
                        {
                            ProductId = 11,
                            CategoryId = 4,
                            Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                            ImageUrl = "https://www.pizzalazza.com.tr/PictureUpload/f9f21de3-2c80-4423-958d-3f5803da34c7_.jpg",
                            Name = "Sufle",
                            Price = 34.0
                        },
                        new
                        {
                            ProductId = 12,
                            CategoryId = 4,
                            Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                            ImageUrl = "https://static.ticimax.cloud/54612/uploads/urunresimleri/fistikli-burma-kadayif-d-a1f8.jpg",
                            Name = "Fıstıklı Burma Kadayıf",
                            Price = 40.0
                        },
                        new
                        {
                            ProductId = 13,
                            CategoryId = 4,
                            Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                            ImageUrl = "https://www.diyetkolik.com/site_media/media/foodrecipe_images/kazandibi_1.jpg",
                            Name = "Kazandibi",
                            Price = 28.0
                        },
                        new
                        {
                            ProductId = 14,
                            CategoryId = 5,
                            Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                            ImageUrl = "https://bilgemar.com/Resim/Minik/1500x1500_thumb_5376-8.jpg",
                            Name = "Su",
                            Price = 28.0
                        },
                        new
                        {
                            ProductId = 15,
                            CategoryId = 5,
                            Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                            ImageUrl = "https://images.migrosone.com/sanalmarket/product/11554181/11554181-bc0a47-1650x1650.jpg",
                            Name = "Ayran",
                            Price = 28.0
                        });
                });

            modelBuilder.Entity("Inveon.Services.ProductAPI.Models.Product", b =>
                {
                    b.HasOne("Inveon.Services.ProductAPI.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Inveon.Services.ProductAPI.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
