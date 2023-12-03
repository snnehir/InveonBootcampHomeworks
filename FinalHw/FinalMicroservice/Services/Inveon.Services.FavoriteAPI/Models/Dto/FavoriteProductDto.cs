namespace Inveon.Services.FavoriteAPI.Models.Dto
{
	public class FavoriteProductDto
	{
        public int FavoriteProductId { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
	}
}
