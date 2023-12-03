using Inveon.Services.FavoriteAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Inveon.Services.FavoriteAPI.DbContexts
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
		public DbSet<Product> Products { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Product>()
						.HasMany(e => e.FavoriteProducts)
						.WithOne(e => e.Product)
						.HasForeignKey(e => e.ProductId)
						.IsRequired();

		}

	}
}
