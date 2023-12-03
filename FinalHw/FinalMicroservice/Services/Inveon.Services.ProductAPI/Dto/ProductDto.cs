﻿namespace Inveon.Services.ProductAPI.Dto
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
		public string CategoryId { get; set; }
		public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
