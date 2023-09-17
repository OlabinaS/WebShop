using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Dto.Item
{
	public class AddItemDto
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int Quantity { get; set; }
		public double Price { get; set; }
	}
}
