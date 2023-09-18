using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using WebShop.Dto;
using WebShop.Dto.User;
using WebShop.Helper;
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
		private readonly ITokenHelper _token;
		private readonly IDbHelper _dbHelper;
		private readonly UserHelper _userHelper;


		public UserService(IMapper mapper, ITokenHelper token, IDbHelper dbHelper)
		{
			_mapper = mapper;
			_token = token;
			_dbHelper = dbHelper;
			_userHelper = new UserHelper(_dbHelper);
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
			if (registrationDto.Role == "Customer")
				if (_dbHelper.customerRepository.FindFirst(a => a.Email == registrationDto.Email) != null || _dbHelper.customerRepository.FindFirst(a => a.Username == registrationDto.Username) != null)
					return "Exist";

			if(registrationDto.Role == "Seller")
				if (_dbHelper.sellerRepository.FindFirst(a => a.Email == registrationDto.Email) != null || _dbHelper.sellerRepository.FindFirst(a => a.Username == registrationDto.Username) != null)
					return "Exist";

			//Check for role
			if (registrationDto.Role.Equals("Customer"))
			{
				Customer customer = _mapper.Map<Customer>(registrationDto);
				customer.Password = BCrypt.Net.BCrypt.HashPassword(registrationDto.Password);
				_dbHelper.customerRepository.Add(customer);
			}
			else if(registrationDto.Role.Equals("Seller"))
			{
				Seller seller = _mapper.Map<Seller>(registrationDto);
				seller.Verification = Ver.Pending;
				seller.Password = BCrypt.Net.BCrypt.HashPassword(registrationDto.Password);
				_dbHelper.sellerRepository.Add(seller);
				//send email

			}
			else
			{
				return "Bad";
			}
			//save changes
			_dbHelper.SaveChange();

			return "Ok";
		}

		public string Login(LoginDto loginDto)
		{
			Usr user = new Usr();
			//does email exist
			if (_dbHelper.customerRepository.FindFirst(a => a.Email == loginDto.Email) is Customer customer)
			{
				user = new Usr(customer);
			}
			else if (_dbHelper.adminRepository.FindFirst(a => a.Email == loginDto.Email) is Admin admin)
			{
				user = new Usr(admin);
			}
			else if (_dbHelper.sellerRepository.FindFirst(a => a.Email == loginDto.Email) is Seller seller)
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

		public object IsLoggedIn(ClaimsPrincipal user)
		{
			if (user.Identity.IsAuthenticated)
			{
				var userId = user.FindFirst("id")?.Value;
				var username = user.FindFirst("username")?.Value;
				var userRole = user.FindFirst(ClaimTypes.Role)?.Value;
				var name = user.FindFirst("name")?.Value;
				var lastname = user.FindFirst("lastname")?.Value;
				var email = user.FindFirst(ClaimTypes.Email)?.Value;
				var bday = user.FindFirst(ClaimTypes.DateOfBirth)?.Value;

				return (new { IsLoggedIn = true, UserId = userId, Username = username, Role = userRole, Name = name, Lastname = lastname, Email = email, BDay = bday });
			}

			return (new { IsLoggedIn = false });
		}

		public string GetNewToken(ClaimsPrincipal user)
		{
			string userId = null;
			if(user.Identity.IsAuthenticated)
			{
				userId = user.FindFirst("id")?.Value;
			}

			long Id = long.Parse(userId);
			Usr usr = new Usr();

			if (_dbHelper.customerRepository.FindFirst(a => a.Id == Id) is Customer customer)
			{
				usr = new Usr(customer);
			}
			else if (_dbHelper.adminRepository.FindFirst(a => a.Id == Id) is Admin admin)
			{
				usr = new Usr(admin);
			}
			else if (_dbHelper.sellerRepository.FindFirst(a => a.Id == Id) is Seller seller)
			{
				usr = new Usr(seller);
			}
			else
			{
				return "NotExist";
			}

			string token = _token.GetToken(usr);
			TokenDto tokenDto = new TokenDto(token);

			return token;
		}

		public string UpdateUser(string token, NewUserDto newUserDto)
		{
			IResultHelper result = _userHelper.UserByToken(token, _token);
			User currentUser = null;

			if (result.Type == "admin")
				currentUser = (Admin)result.User;
			else if (result.Type == "customer")
				currentUser = (Customer)result.User;
			else if (result.Type == "seller")
				currentUser = (Seller)result.User;

			Usr newUser = _mapper.Map<Usr>(newUserDto);

			if(currentUser == null)
			{
				return "User doesn't exist!";
			}
			if(newUser == null)
			{
				return "Can't update!";
			}
			if (_userHelper.UserByEmail(newUser.Email) != null && newUser.Email != currentUser.Email)
			{
				//result = new Result(false, ErrorCode.Conflict, $"Username {newUser.Username} already exists!");
				return $"User with {newUser.Email} already exists!";
			}

			if (newUser.Username != "string" && newUser.Username != "" && newUser.Username != null)
				currentUser.Username = newUser.Username;
			if (newUser.Name != "string" && newUser.Name != "" && newUser.Name != null)
				currentUser.Name = newUser.Name;
			if (newUser.Lastname != "string" && newUser.Lastname != "" && newUser.Lastname != null)
				currentUser.Lastname = newUser.Lastname;
			if (newUser.Address != "string" && newUser.Address != "" && newUser.Address != null)
				currentUser.Address = newUser.Address;
			if (newUser.Email != "string" && newUser.Email != "" && newUser.Email != null)
				currentUser.Email = newUser.Email;
			if (newUser.BDay != System.DateTime.MinValue)
				currentUser.BDay = newUser.BDay;

			if(currentUser.GetType() == typeof(Admin))
			{
				//Admin admin = _mapper.Map<Admin>(currentUser);
				_dbHelper.adminRepository.Update((Admin)currentUser);
			}
			else if (currentUser.GetType() == typeof(Customer))
			{
				//Customer customer = _mapper.Map<Customer>(currentUser);
				//_dbHelper.customerRepository.Delete(customer);
				//_dbHelper.SaveChange();
				//_dbHelper.customerRepository.Add(customer);
				

				_dbHelper.customerRepository.Update((Customer)currentUser);
			}
			else if(currentUser.GetType() == typeof(Seller))
			{
				//Seller seller = _mapper.Map<Seller>(currentUser);
				_dbHelper.sellerRepository.Update((Seller)currentUser);
			}
			else
			{
				return "NotFound";
			}

			_dbHelper.SaveChange();

			return "";

		}
	}
}
