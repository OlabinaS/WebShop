using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Helper.Interfaces;
using WebShop.Infrastructure;
using WebShop.Repository;
using WebShop.Repository.Interfaces;

namespace WebShop.Helper
{
	public class DbHelper : IDbHelper
	{
		private readonly WebShopDbContext _dbContext;

		public IAdminRepository adminRepository { get; set; }
		public ISellerRepository sellerRepository { get; set; }
		public ICustomerRepository customerRepository { get; set; }
		public IItemRepository itemRepository { get; set; }

		public DbHelper(WebShopDbContext dbContext)
		{
			_dbContext = dbContext;

			adminRepository = new AdminRepository(dbContext);
			customerRepository = new CustomerRepository(dbContext);
			sellerRepository = new SellerRepository(dbContext);
			itemRepository = new ItemRepository(dbContext);
			
		}

		public void SaveChange()
		{
			_dbContext.SaveChanges();
		}
	}
}
