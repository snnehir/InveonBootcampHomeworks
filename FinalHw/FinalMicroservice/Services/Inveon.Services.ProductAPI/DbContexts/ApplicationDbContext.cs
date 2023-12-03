using Inveon.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Inveon.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }



		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Category>()
		                .HasMany(e => e.Products)
		                .WithOne(e => e.Category)
		                .HasForeignKey(e => e.CategoryId)
		                .IsRequired();

			modelBuilder.Entity<Category>().HasData(new Category
			{
				CategoryId = 1,
				CategoryName = "Çorbalar"
			});
			modelBuilder.Entity<Category>().HasData(new Category
			{
				CategoryId = 2,
				CategoryName = "Salatalar"
			});
			modelBuilder.Entity<Category>().HasData(new Category
			{
				CategoryId = 3,
				CategoryName = "Kebaplar"
			});
			modelBuilder.Entity<Category>().HasData(new Category
			{
				CategoryId = 4,
				CategoryName = "Tatlılar"
			});
			modelBuilder.Entity<Category>().HasData(new Category
			{
				CategoryId = 5,
				CategoryName = "İçecekler"
			});

			modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Mercimek Çorbası",
                Price = 20,
                Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                ImageUrl = "https://i.pinimg.com/564x/1e/de/af/1edeaf4dc2af2af8a8b4cc41fae36d32.jpg",
                CategoryId = 1,
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Yayla Çorbası",
                Price = 25,
                Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                ImageUrl = "https://m.media-amazon.com/images/I/81T9e8e8wJL._AC_UF1000,1000_QL80_.jpg",
				CategoryId = 1,
			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				ProductId = 3,
				Name = "Kelle Paça Çorbası",
				Price = 25,
				Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
				ImageUrl = "https://www.mirzausta.com/wp-content/uploads/2021/01/kelle-paca-corbasi.jpg",
				CategoryId = 1,
			});

			modelBuilder.Entity<Product>().HasData(new Product
			{
				ProductId = 4,
				Name = "Akdeniz Salata",
				Price = 15,
				Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
				ImageUrl = "https://www.tasocakfirin.com/image/cache/catalog/products_2021/Akdeniz-Salata-1000x1000.jpg",
				CategoryId = 2,
			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				ProductId = 5,
				Name = "Ton Balıklı Salata",
				Price = 18,
				Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
				ImageUrl = "https://www.diyetkolik.com/site_media/media/nutrition_images/44_Ton_Balkl_Gemici_Salatas.jpg",
				CategoryId = 2,
			});

			modelBuilder.Entity<Product>().HasData(new Product
			{
				ProductId = 6,
				Name = "Adana Kebap",
				Price = 60,
				Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
				ImageUrl = "https://www.cankebap.com.tr/wp-content/uploads/2023/07/adana-kebab-can-kebap.jpg",
				CategoryId = 3,
				
			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				ProductId = 7,
				Name = "Tavuk Şiş Kebap",
				Price = 54,
				Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
				ImageUrl = "https://static.ticimax.cloud/44658/uploads/urunresimleri/buyuk/tavuk-sis--53-83c.jpg",
				CategoryId = 3,
				
			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				ProductId = 8,
				Name = "Kuzu Şiş Kebap",
				Price = 70,
				Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
				ImageUrl = "https://www.gozdekebap.com/wp-content/uploads/2020/04/sirinevler-kuzu-sis.jpg",
				CategoryId = 3,
				
			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				ProductId = 9,
				Name = "Urfa Kebap",
				Price = 60,
				Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
				ImageUrl = "https://www.diyetkolik.com/site_media/media/foodrecipe_images/ufra-kabap.png",
				CategoryId = 3,
				
			});

			modelBuilder.Entity<Product>().HasData(new Product
			{
				ProductId = 10,
				Name = "Künefe",
				Price = 30,
				Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
				ImageUrl = "https://media-cdn.tripadvisor.com/media/photo-s/13/59/46/a7/photo0jpg.jpg",
				CategoryId = 4,
			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				ProductId = 11,
				Name = "Sufle",
				Price = 34,
				Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
				ImageUrl = "https://www.pizzalazza.com.tr/PictureUpload/f9f21de3-2c80-4423-958d-3f5803da34c7_.jpg",
				CategoryId = 4,
			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				ProductId = 12,
				Name = "Fıstıklı Burma Kadayıf",
				Price = 40,
				Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
				ImageUrl = "https://static.ticimax.cloud/54612/uploads/urunresimleri/fistikli-burma-kadayif-d-a1f8.jpg",
				CategoryId = 4,
			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				ProductId = 13,
				Name = "Kazandibi",
				Price = 28,
				Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
				ImageUrl = "https://www.diyetkolik.com/site_media/media/foodrecipe_images/kazandibi_1.jpg",
				CategoryId = 4,
			});

			modelBuilder.Entity<Product>().HasData(new Product
			{
				ProductId = 14,
				Name = "Su",
				Price = 4,
				Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
				ImageUrl = "https://bilgemar.com/Resim/Minik/1500x1500_thumb_5376-8.jpg",
				CategoryId = 5,
			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				ProductId = 15,
				Name = "Ayran",
				Price = 10,
				Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
				ImageUrl = "https://images.migrosone.com/sanalmarket/product/11554181/11554181-bc0a47-1650x1650.jpg",
				CategoryId = 5,
			});
		}
    }
}
