using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Dto.Item;
using WebShop.Helper.Interfaces;
using WebShop.Models;

namespace WebShop.Helper
{
	public class ResultHelper : IResultHelper
	{
		public bool Success { get; set; }
		public ItemListDto ItemListDto { get; set; }
		public string Text { get; set; }
		public User User { get; set; }
		public string Type { get; set; }

		public ResultHelper()
		{

		}
		public ResultHelper(string type, User user)
		{
			User = user;
			Type = type;
		}
		public ResultHelper(bool success, string text, ItemListDto itemListDto)
		{
			Success = success;
			Text = text;
			ItemListDto = itemListDto;
		}
		public ResultHelper(bool success, string text)
		{
			Success = success;
			Text = text;
		}
	}
}
