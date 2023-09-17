using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Infrastructure;
using WebShop.Repository.Interfaces;

namespace WebShop.Helper.Interfaces
{
	public interface IDbHelper
	{
		//public WebShopDbContext _dbContext { get; set; }
		public IAdminRepository adminRepository { get; set; }
		public ISellerRepository sellerRepository { get; set; }
		public ICustomerRepository customerRepository { get; set; }
		public IItemRepository itemRepository { get; set; }

		void SaveChange();
	}
}
