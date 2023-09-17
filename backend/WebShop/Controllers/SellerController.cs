using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Dto.Item;
using WebShop.Helper;
using WebShop.Helper.Interfaces;
using WebShop.Interfaces;

namespace WebShop.Controllers
{
	[Route("api/seller")]
	[ApiController]
	public class SellerController : Controller
	{
		private readonly ISellerService _sellerService;

		public SellerController(ISellerService sellerService)
		{
			_sellerService = sellerService;
		}

		[HttpGet("items")]
		//[Authorize(Roles = "Seller")]
		public IActionResult GetItems()
		{
			IResultHelper result = null;
			try
			{
				string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").LastOrDefault();

				result = _sellerService.GetAllItems(token);
				if(!result.Success)
				{
					return BadRequest(result.Text);
				}

				return Ok(result.ItemListDto);
			}
			catch(Exception)
			{
				return StatusCode(500);
			}
		}


		[HttpPost("item")]
		//[Authorize(Roles = "Seller")]
		public IActionResult AddItem([FromForm] AddItemDto addItemDto)
		{
			try
			{
				string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").LastOrDefault();
				string result = _sellerService.AddItems(addItemDto, token);

				if (result != "Ok")
				{
					return BadRequest(result);
				}
				return Ok();
			}
			catch (Exception e)
			{
				return StatusCode(500);
			}
		}

	}
}
