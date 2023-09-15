using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Infrastructure;
using WebShop.Models;
using WebShop.Repository.Interfaces;

namespace WebShop.Repository
{
	public class SellerRepository : Repository<Seller>, ISellerRepository
	{
		public SellerRepository(WebShopDbContext context) : base(context)
		{
			
		}
	}
}
