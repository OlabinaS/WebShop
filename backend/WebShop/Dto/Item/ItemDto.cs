using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Dto
{
	public class ItemDto
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Quantity { get; set; }
		public double Price { get; set; }


		public ItemDto(long itemId, string name, string description, int quantity, double price)
		{
			Id = itemId;
			Name = name;
			Description = description;
			Quantity = quantity;
			Price = price;
		}
	}
}
