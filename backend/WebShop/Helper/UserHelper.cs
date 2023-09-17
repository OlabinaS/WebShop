using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Helper.Interfaces;
using WebShop.Infrastructure;
using WebShop.Models;
using WebShop.Repository;
using WebShop.Repository.Interfaces;

namespace WebShop.Helper
{
	public class UserHelper : IUserHelper
	{
		private readonly WebShopDbContext _dbContext;

		AdminRepository adminRepo;
        CustomerRepository customerRepo;
        SellerRepository sellerRepo;

        public UserHelper(WebShopDbContext dbContext)
		{
			_dbContext = dbContext;
			adminRepo = new AdminRepository(_dbContext);
            customerRepo = new CustomerRepository(_dbContext);
            sellerRepo = new SellerRepository(_dbContext);
			
		}
		public Usr UserByToken(string token, ITokenHelper _tokenHelper)
		{
            long id = int.Parse(_tokenHelper.GetClaim(token, "id"));
            string role = _tokenHelper.GetClaim(token, "role");
            Usr user;
            if (role.Equals("Admin") && adminRepo.FindFirst(a => a.Id == id) is Admin admin)
                user = new Usr(admin);
            else if (role.Equals("Customer") && customerRepo.FindFirst(c => c.Id == id) is Customer customer)
                user = new Usr(customer);
            else if (role.Equals("Seller") && sellerRepo.FindFirst(s => s.Id == id) is Seller seller)
                user = new Usr(seller);
            else
                return null;

            return user;
        }
	}
}
