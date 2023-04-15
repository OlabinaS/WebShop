using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
	public class ItemInOrder
	{
		public long OrderId { get; set; }
		public Order Order { get; set; }
		public long ItemId { get; set; }
		public Item Item { get; set; }
		public int Quantity { get; set; }
		public double Price { get; set; }
	}
}
