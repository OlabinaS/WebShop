using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Dto.Item;
using WebShop.Models;

namespace WebShop.Helper.Interfaces
{
	public interface IResultHelper
	{
		public bool Success { get; set; }
		public ItemListDto ItemListDto { get; set; }
		public string Text { get; set; }
		public User User { get; set; }
		public string Type { get; set; }

	}
}
