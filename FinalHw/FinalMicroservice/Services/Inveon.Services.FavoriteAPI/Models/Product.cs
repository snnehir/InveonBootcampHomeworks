﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inveon.Services.FavoriteAPI.Models
{
	public class Product
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ProductId { get; set; }
		[Required]
		public string Name { get; set; }
		[Range(1, 1000)]
		public double Price { get; set; }
		public string Description { get; set; }
		public string CategoryName { get; set; }
		public string ImageUrl { get; set; }
        public ICollection<FavoriteProduct> FavoriteProducts { get; set; }
    }
}