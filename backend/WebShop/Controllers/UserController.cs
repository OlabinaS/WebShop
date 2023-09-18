using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebShop.Dto;
using WebShop.Dto.User;
using WebShop.Interfaces;

namespace WebShop.Controllers
{
	[Route("api/users")]
	[ApiController]
	public class UserController : Controller
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpPost("registration")]
		public IActionResult Register([FromForm] RegistrationDto registrationDto)
		{
			try
			{
				string result = _userService.Registration(registrationDto);

				if (result.Equals("Exist"))
				{
					return Conflict();
				}
				else if(result.Equals("Bad"))
				{
					return BadRequest();
				}


				return Ok();
			}
			catch(Exception)
			{
				return StatusCode(500);
			}
		}

		[HttpPost("login")]
		public IActionResult Login([FromForm] LoginDto loginDto)
		{
			try
			{
				string token = _userService.Login(loginDto);

				if (token == "NotExist")
				{
					return NotFound();
				}
				else if (token == "IncorrectPassword")
					return Unauthorized();

				CookieOptions options = new CookieOptions();
				options.Expires = DateTime.Now.AddMinutes(20);
				options.SameSite = SameSiteMode.None;
				Response.Cookies.Append("Authorization", $"Berer {token}");

				return Ok(token);
			}
			catch(Exception)
			{
				return StatusCode(500);
			}
		}

		//[Authorize]
		[HttpGet("isLoggedIn")]
		public IActionResult IsLoggedIn()
		{
			try
			{
				object result = _userService.IsLoggedIn(User);

				return Ok(result);
			}
			catch (Exception)
			{
				return StatusCode(500);
			}
		}

		[HttpGet("newToken")]
		public IActionResult GetNewToken()
		{
			try
			{
				string token = _userService.GetNewToken(User);

				if(token == "NotExist")
				{
					return StatusCode(500);
				}
				return Ok(token);
			}
			catch (Exception)
			{
				return StatusCode(500);
			}
		}


		[HttpPut("update-user")]
		public IActionResult UpdateUser([FromForm] NewUserDto newUserDto)
		{
			try
			{
				string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").LastOrDefault();

				string result = _userService.UpdateUser(token, newUserDto);
				if(result != "")
				{
					return BadRequest(result);
				}
				return Ok();
			}
			catch(Exception)
			{
				return StatusCode(500);
			}
		}
	}
}
