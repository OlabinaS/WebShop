using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Helper.Interfaces
{
	public interface ITokenHelper
	{
		string GetToken(Usr user);
	}
}
