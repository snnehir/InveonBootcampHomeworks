using System.ComponentModel.DataAnnotations.Schema;

namespace Inveon.Services.OrderAPI.Models.Dto
{
	public class OrderDetailDto
	{
		public int OrderDetailsId { get; set; }
		public int Count { get; set; }
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public double Price { get; set; }
	}
}
