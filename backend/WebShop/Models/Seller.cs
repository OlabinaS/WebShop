using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
	public enum Ver { accepted, declined, processing }
	public class Seller : User
	{
		public Ver Verification { get; set; }
		public List<Item> Items { get; set; }
	}
}
