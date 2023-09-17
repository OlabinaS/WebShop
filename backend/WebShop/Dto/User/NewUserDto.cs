using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Dto.User
{
	public class NewUserDto
	{
		public string Name { get; set; }
		public string Lastname { get; set; }
		public string Username { get; set; }
		public string Address { get; set; }
		public DateTime Birthdate { get; set; }
		public string Email { get; set; }
	}
}
