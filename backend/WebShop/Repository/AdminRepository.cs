using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Infrastructure;
using WebShop.Models;

namespace WebShop.Repository.Interfaces
{
	public class AdminRepository : Repository<Admin>, IAdminRepository
	{
		public AdminRepository(WebShopDbContext context) : base(context)
		{

		}
	}
}
