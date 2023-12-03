using Azure;
using Inveon.Services.FavoriteAPI.Models.Dto;
using Inveon.Services.FavoriteAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inveon.Services.FavoriteAPI.Controllers
{
	[Route("api/favorite")]
	[ApiController]
	public class FavoriteAPIController : ControllerBase
	{
		protected ResponseDto _response;
		private readonly IFavoriteRepository _favoriteRepository;
		
		public FavoriteAPIController(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
			_response = new ResponseDto();
        }

		[HttpGet("{userId}")]
		public async Task<object> GetFavorites(string userId)
		{
			try
			{
				IEnumerable<FavoriteProductDto> favoriteDto = await _favoriteRepository.GetFavoriteProductsByUserId(userId);
				_response.Result = favoriteDto;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
			}
			return _response;
		}



		[HttpPost]
		[Authorize]
		public async Task<object> Post([FromBody] AddFavoriteProductDto favoriteDto)
		{
			try
			{
				await _favoriteRepository.CreateFavorite(favoriteDto);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages
					 = new List<string>() { ex.ToString() };
			}
			return _response;
		}

		

		[HttpDelete("{id}")]
		[Authorize]
		public async Task<object> RemoveFavorite([FromBody] int id)
		{
			try
			{
				bool isSuccess = await _favoriteRepository.RemoveFromFavorites(id);
				_response.Result = isSuccess;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
			}
			return _response;
		}
	}
}
