using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using WebShop.Dto;
using WebShop.Helper.Interfaces;
using WebShop.Infrastructure;
using WebShop.Interfaces;
using WebShop.Models;
using WebShop.Repository;
using WebShop.Repository.Interfaces;

namespace WebShop.Services
{
	public class UserService : IUserService
	{
		private readonly IMapper _mapper;
		private WebShopDbContext _dbContext;
		private readonly ITokenHelper _token;

		AdminRepository adminRepo;
		CustomerRepository customerRepo;
		SellerRepository sellerRepo;

		public UserService(IMapper mapper, WebShopDbContext dbContext, ITokenHelper token)
		{
			_mapper = mapper;
			_dbContext = dbContext;
			_token = token;

			adminRepo = new AdminRepository(_dbContext);
			customerRepo = new CustomerRepository(_dbContext);
			sellerRepo = new SellerRepository(_dbContext);
		}

		
		public string Registration(RegistrationDto registrationDto)
		{
			//email validation
			var mailAddres = new MailAddress("aa@aa.aa");
			try
			{
				if (string.IsNullOrEmpty(registrationDto.Email))
				{
					throw new FormatException("Empty mail string");
				}
				mailAddres = new MailAddress(registrationDto.Email);
			}
			catch (FormatException)
			{
				return "Bad";
			}

			//Does user exist
			if (_dbContext.Customers.Any(a => a.Email == registrationDto.Email))
				return "Exist";

			if (_dbContext.Sellers.Any(a => a.Email == registrationDto.Email))
				return "Exist";

			if (_dbContext.Customers.Any(a => a.Username == registrationDto.Username))
				return "Exist";

			if (_dbContext.Sellers.Any(a => a.Username == registrationDto.Username))
				return "Exist";

			//Check for role
			if (registrationDto.Role.Equals("Customer"))
			{
				Customer customer = _mapper.Map<Customer>(registrationDto);
				customer.Password = BCrypt.Net.BCrypt.HashPassword(registrationDto.Password);
				customerRepo.Add(customer);
			}
			else if(registrationDto.Role.Equals("Seller"))
			{
				Seller seller = _mapper.Map<Seller>(registrationDto);
				seller.Verification = Ver.Pending;
				seller.Password = BCrypt.Net.BCrypt.HashPassword(registrationDto.Password);
				sellerRepo.Add(seller);
				//send email

			}
			else
			{
				return "Bad";
			}
			//save changes
			_dbContext.SaveChanges();

			return "Ok";
		}

		public string Login(LoginDto loginDto)
		{
			Usr user = new Usr();
			//does email exist
			if (customerRepo.FindFirst(a => a.Email == loginDto.Email) is Customer customer)
			{
				user = new Usr(customer);
			}
			else if (adminRepo.FindFirst(a => a.Email == loginDto.Email) is Admin admin)
			{
				user = new Usr(admin);
			}
			else if (sellerRepo.FindFirst(a => a.Email == loginDto.Email) is Seller seller)
			{
				user = new Usr(seller);
			}
			else
			{
				return "NotExist";
			}

			//password validation
			if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
				return "IncorrectPassword";

			//token
			string token = _token.GetToken(user);
			TokenDto tokenDto = new TokenDto(token);

			return token;

			//throw new NotImplementedException();
		}

	}
}
