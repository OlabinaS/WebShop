using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Interfaces;

namespace WebShop.Controllers
{
	[Route("api/admin")]
	[ApiController]
	public class AdminController : Controller
	{
		private readonly IAdminService _adminService;

		public AdminController(IAdminService adminService)
		{
			_adminService = adminService;
		}

		[HttpGet("sellers")]
		//[Authorize(Roles = "Admin")]
		public IActionResult GetAllSellers()
		{
			try
			{
				object result = _adminService.GetAllSellers();

				return Ok(result);
			}
			catch(Exception)
			{
				return StatusCode(500);
			}
		}
	}
}
