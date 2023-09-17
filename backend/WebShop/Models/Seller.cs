using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
	public enum Ver { Pending, Approved, Denied}
	public class Seller : User
	{
		public Ver Verification { get; set; }
		public List<Item> Items { get; set; }

		public Seller()
		{

		}
		public Seller(Usr user)
		{
			this.Id = user.Id;
			this.Name = user.Name;
			this.Lastname = user.Lastname;
			this.Email = user.Email;
			this.Password = user.Password;
			this.Address = user.Address;
			this.Username = user.Username;
			this.BDay = user.BDay;
			this.Verification = user.verification;
		}
	}
}
