using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Helper.Interfaces;
using WebShop.Models;

namespace WebShop.Helper
{
	public class SellerHelper : ISellerHelper
	{
		public List<Item> GetItemsOfSeller(List<Item> items, long sellerId)
		{
			List<Item> result = new List<Item>();

			foreach (var item in items)
			{
				if (item.SellerId == sellerId)
					result.Add(item);
			}
			return result;

		}
	}
}
