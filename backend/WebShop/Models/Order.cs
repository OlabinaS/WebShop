using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
	public class Order
	{
		public long Id { get; set; }
		public long CustomerId { get; set; }
		public Customer Customer { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime DeliveryDate { get; set; }
		public string Address { get; set; }
		public string Comment { get; set; }
		public List<ItemInOrder> Items { get; set; }
	}
}
