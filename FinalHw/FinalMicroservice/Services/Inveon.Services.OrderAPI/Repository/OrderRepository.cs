using AutoMapper;
using Inveon.Services.OrderAPI.DbContexts;
using Inveon.Services.OrderAPI.Models;
using Inveon.Services.OrderAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Inveon.Services.OrderAPI.Repository
{

    public class OrderRepository : IOrderRepository
    {
        private readonly DbContextOptions<ApplicationDbContext> _dbContext;
		private IMapper _mapper;
		

		public OrderRepository(DbContextOptions<ApplicationDbContext> dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

		public OrderRepository(DbContextOptions<ApplicationDbContext> options)
		{
			_dbContext = options;
		}

		public async Task<bool> AddOrder(OrderHeader orderHeader)
        {
            if (orderHeader.CouponCode == null)
            {
                orderHeader.CouponCode = "";
            }
            await using var _db = new ApplicationDbContext(_dbContext);
            _db.OrderHeaders.Add(orderHeader);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task UpdateOrderPaymentStatus(int orderHeaderId, bool paid)
        {
            await using var _db = new ApplicationDbContext(_dbContext);
            var orderHeaderFromDb = await _db.OrderHeaders.FirstOrDefaultAsync(u => u.OrderHeaderId == orderHeaderId);
            if (orderHeaderFromDb != null)
            {
                orderHeaderFromDb.PaymentStatus = paid;
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<OrderHeaderDto>> GetOrdersByUserId(string userId)
        {
			await using var _db = new ApplicationDbContext(_dbContext);
			var orderHeaders = await _db.OrderHeaders.Where(u => u.UserId.Equals(userId)).ToListAsync();
            return _mapper.Map<List<OrderHeaderDto>>(orderHeaders);
		}
    }
}
