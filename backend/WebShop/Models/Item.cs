using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
	public class Item
	{
		public long Id { get; set; }
		public long SellerId { get; set; }
		public Seller Seller { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public int Quantity { get; set; }
		public string Description { get; set; }

	}
}
