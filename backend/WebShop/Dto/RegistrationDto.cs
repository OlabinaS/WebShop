using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Dto
{
	public class RegistrationDto
	{
		public string Name { get; set; }
		public string Lastname { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string PasswordConfirm { get; set; }
		public string Address { get; set; }
		public DateTime BDay { get; set; }
		public string Role { get; set; }


	}
}
