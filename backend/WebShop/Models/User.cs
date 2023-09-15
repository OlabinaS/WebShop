﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
	public abstract class User
	{
		public long Id { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string Name { get; set; }
		public string Lastname { get; set; }
		public string Password { get; set; }
		public DateTime BDay { get; set; }
		public string Address { get; set; }

	}
}
