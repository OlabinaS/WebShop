using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebShop.Dto;

namespace WebShop.Interfaces
{
	public interface IUserService
	{
		public string Registration(RegistrationDto registrationDto);
		public string Login(LoginDto loginDto);
		public object IsLoggedIn(ClaimsPrincipal user);

	}
}
