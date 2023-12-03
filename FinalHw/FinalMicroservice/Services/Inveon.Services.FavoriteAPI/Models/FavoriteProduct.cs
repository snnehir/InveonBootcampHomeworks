namespace Inveon.Services.FavoriteAPI.Models
{
	public class FavoriteProduct
	{
		public int FavoriteProductId { get; set; }
		public string UserId { get; set; }
		public int ProductId { get; set; }

		public virtual Product Product { get; set; }
	}
}
