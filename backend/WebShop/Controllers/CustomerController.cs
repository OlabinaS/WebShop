using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Interfaces;

namespace WebShop.Controllers
{
	[Route("api/customer")]
	[ApiController]
	public class CustomerController : Controller
	{
		private readonly ICustomerService _customerService;

		public CustomerController(ICustomerService customerService)
		{
			_customerService = customerService;
		}

		[HttpGet("items")]
		//[Authorize(Roles = "Customer")]
		public IActionResult GetItems()
		{
			try
			{
				object result = _customerService.GetItems();

				return Ok(result);
			}
			catch(Exception)
			{
				return StatusCode(500);
			}
		}

		/*[HttpPost("checkout-order")]
		public IActionResult CheckoutOrder()
		{
			//List Decs, qua, name, price, id


		}*/

	}
}
