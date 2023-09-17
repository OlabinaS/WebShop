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
		private readonly IDbHelper _dbHelper;

		public UserHelper(IDbHelper dbHelper)
		{
			_dbHelper = dbHelper;
		}

		public Usr UserByEmail(string email)
		{
            Usr user;
            if (_dbHelper.adminRepository.FindFirst(u => u.Email == email) is Admin admin)
            {
                user = new Usr(admin);
            }
            else if (_dbHelper.customerRepository.FindFirst(u => u.Email == email) is Customer customer)
            {
                user = new Usr(customer);
            }
            else if (_dbHelper.sellerRepository.FindFirst(u => u.Email == email) is Seller seller)
            {
                user = new Usr(seller);
            }
            else
                return null;

            return user;
		}

		public IResultHelper UserByToken(string token, ITokenHelper _tokenHelper)
		{
            long id = int.Parse(_tokenHelper.GetClaim(token, "id"));
            string role = _tokenHelper.GetClaim(token, "role");
            if (role.Equals("Admin") && _dbHelper.adminRepository.FindFirst(a => a.Id == id) is Admin admin)
                return new ResultHelper("admin",(User)admin);
            //user = new Usr(admin);
            else if (role.Equals("Customer") && _dbHelper.customerRepository.FindFirst(c => c.Id == id) is Customer customer)
                return new ResultHelper("customer", (User)customer);
            //user = new Usr(customer);
            else if (role.Equals("Seller") && _dbHelper.sellerRepository.FindFirst(s => s.Id == id) is Seller seller)
                return new ResultHelper("seller", (User)seller);
            //user = new Usr(seller);
            else
                return null;

        }

	}
}
