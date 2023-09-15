using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Dto
{
	public class TokenDto
	{
		public string Token { get; set; }
		public TokenDto(string token)
		{
			Token = token;
		}
	}
}
