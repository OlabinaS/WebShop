using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Dto;
using WebShop.Dto.Item;
using WebShop.Helper.Interfaces;
using WebShop.Infrastructure;
using WebShop.Interfaces;
using WebShop.Models;
using WebShop.Repository;

namespace WebShop.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly IMapper _mapper;
		private readonly ITokenHelper _token;
		private readonly IDbHelper _dbHelper;

		public CustomerService(IMapper mapper, ITokenHelper	token, IDbHelper dbHelper)
		{
			_mapper = mapper;
			_token = token;
			_dbHelper = dbHelper;

		}
		public object GetItems()
		{
			List<Item> itemsDB = _dbHelper.itemRepository.GetAll().ToList();
			List<ItemDto> itemsDto = new List<ItemDto>();

			foreach(Item item in itemsDB)
			{
				itemsDto.Add(new ItemDto(item.Id, item.Name, item.Description, item.Quantity, item.Price));
			}

			ItemListDto itemListDto = new ItemListDto() { Items = itemsDto };

			return itemListDto;

			//throw new NotImplementedException();
		}
	}
}
