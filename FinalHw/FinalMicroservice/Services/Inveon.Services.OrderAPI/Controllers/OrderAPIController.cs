using Azure;
using Inveon.Services.OrderAPI.Models.Dto;
using Inveon.Services.OrderAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inveon.Services.OrderAPI.Controllers
{
	[Route("api/order")]
	[ApiController]
	public class OrderAPIController : ControllerBase
	{
		protected ResponseDto _response;
		private IOrderRepository _orderRepository;
		public OrderAPIController(IOrderRepository orderRepository)
        {
			_orderRepository = orderRepository;
			_response = new ResponseDto();
		}

        [HttpGet]
		[Authorize]
		[Route("{userId}")]
		public async Task<object> GetOrdersByUserId(string userId)
		{
			try
			{

				IEnumerable<OrderHeaderDto> orderHeadersDto = await _orderRepository.GetOrdersByUserId(userId);
				_response.Result = orderHeadersDto;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages
					 = new List<string>() { ex.ToString() };
			}
			return _response;
		}
	}
}
