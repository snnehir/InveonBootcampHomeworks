namespace Inveon.Services.FavoriteAPI.Models.Dto
{
	public class AddFavoriteProductDto
	{
		public string UserId { get; set; }
		public int ProductId { get; set; }
		public ProductDto Product { get; set; }
	}
}
