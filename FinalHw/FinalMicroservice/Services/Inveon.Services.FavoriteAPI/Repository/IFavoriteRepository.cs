using Inveon.Services.FavoriteAPI.Models.Dto;

namespace Inveon.Services.FavoriteAPI.Repository
{
	public interface IFavoriteRepository
	{
		Task CreateFavorite(AddFavoriteProductDto favoriteDto);
		Task<IEnumerable<FavoriteProductDto>> GetFavoriteProductsByUserId(string userId);
		Task<bool> RemoveFromFavorites(int favoriteId);
	}
}
