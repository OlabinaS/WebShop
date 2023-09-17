using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
	public class Usr : User
	{
		public string role;
		public Ver verification;
		public Usr()
		{

		}
		public Usr(Customer customer)
		{
			this.Id = customer.Id;
			this.Name = customer.Name;
			this.Lastname = customer.Lastname;
			this.Email = customer.Email;
			this.Password = customer.Password;
			this.Address = customer.Address;
			this.Username = customer.Username;
			this.BDay = customer.BDay;
			role = "Customer";
			verification = Ver.Approved;
		}

		public Usr(Seller seller)
		{
			this.Id = seller.Id;
			this.Name = seller.Name;
			this.Lastname = seller.Lastname;
			this.Email = seller.Email;
			this.Password = seller.Password;
			this.Address = seller.Address;
			this.Username = seller.Username;
			this.BDay = seller.BDay;
			role = "Seller";
			verification = seller.Verification;
		}

		public Usr(Admin admin)
		{
			this.Id = admin.Id;
			this.Name = admin.Name;
			this.Lastname = admin.Lastname;
			this.Email = admin.Email;
			this.Password = admin.Password;
			this.Address = admin.Address;
			this.Username = admin.Username;
			this.BDay = admin.BDay;
			role = "Admin";
			verification = Ver.Approved;
		}
	}
}
