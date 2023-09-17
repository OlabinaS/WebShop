using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Dto.Seller
{
	public class SellerDto
	{
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Address { get; set; }
		public DateTime Birthdate { get; set; }
		public Ver Verification { get; set; }
		public SellerDto(string firstname, string lastname, string username, string email, string password, string address, DateTime birthdate, Ver verification)
		{
			Firstname = firstname;
			Lastname = lastname;
			Username = username;
			Email = email;
			Password = password;
			Address = address;
			Birthdate = birthdate;
			Verification = verification;
		}
	}
}
