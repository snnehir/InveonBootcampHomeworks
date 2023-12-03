using Inveon.Services.OrderAPI.Models;
using Inveon.Services.OrderAPI.Models.Dto;

namespace Inveon.Services.OrderAPI.Repository
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(OrderHeader orderHeader);
		Task<IEnumerable<OrderHeaderDto>> GetOrdersByUserId(string userId);
		Task UpdateOrderPaymentStatus(int orderHeaderId, bool paid);
    }
}
