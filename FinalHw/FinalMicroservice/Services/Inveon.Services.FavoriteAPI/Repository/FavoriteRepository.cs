using AutoMapper;
using Inveon.Services.FavoriteAPI.DbContexts;
using Inveon.Services.FavoriteAPI.Models;
using Inveon.Services.FavoriteAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Inveon.Services.FavoriteAPI.Repository
{
	public class FavoriteRepository : IFavoriteRepository
	{
		private readonly ApplicationDbContext _db;
		private IMapper _mapper;

		public FavoriteRepository(ApplicationDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}

		public async Task CreateFavorite(AddFavoriteProductDto favoriteDto)
		{
			var favoriteProduct = _mapper.Map<FavoriteProduct>(favoriteDto);
			var prodInDb = await _db.Products.FirstOrDefaultAsync(p => p.ProductId == favoriteDto.ProductId);

			if(prodInDb == null)
			{
				_db.Products.Add(favoriteProduct.Product);
				await _db.SaveChangesAsync();
			}
			else
			{
				_db.Products.Update(favoriteProduct.Product);
				await _db.SaveChangesAsync();
			}

			_db.FavoriteProducts.Add(favoriteProduct);
			await _db.SaveChangesAsync();

		}

		public async Task<IEnumerable<FavoriteProductDto>> GetFavoriteProductsByUserId(string userId)
		{
			var favoriteProducts = await _db.FavoriteProducts.Where(f => f.UserId == userId).Include(f => f.Product).ToListAsync();
			return _mapper.Map<List<FavoriteProductDto>>(favoriteProducts);
		}

		public async Task<bool> RemoveFromFavorites(int favoriteId)
		{
			try
			{
				var favorite = await _db.FavoriteProducts.FirstOrDefaultAsync(f => f.FavoriteProductId == favoriteId);
				_db.FavoriteProducts.Remove(favorite);
				await _db.SaveChangesAsync();
				return true;
			}
			catch (Exception)
			{

				return false;
			}
			
		}
	}
}
