using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Dto.Item;
using WebShop.Helper.Interfaces;

namespace WebShop.Interfaces
{
	public interface ISellerService
	{
		IResultHelper GetAllItems(string token);
		string AddItems(AddItemDto addItemDto, string token);

	}
}
