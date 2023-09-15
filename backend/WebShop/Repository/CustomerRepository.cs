using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Infrastructure;
using WebShop.Models;
using WebShop.Repository.Interfaces;

namespace WebShop.Repository
{
	public class CustomerRepository : Repository<Customer>, ICustomerRepository
	{
		public CustomerRepository(WebShopDbContext context) : base(context)
		{

		}
	}
}
