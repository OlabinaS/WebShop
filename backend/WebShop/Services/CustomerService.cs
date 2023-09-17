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
		private readonly WebShopDbContext _dbContext;

		ItemRepository itemRepo;

		public CustomerService(IMapper mapper, ITokenHelper	token, WebShopDbContext dbContext)
		{
			_mapper = mapper;
			_token = token;
			_dbContext = dbContext;

			itemRepo = new ItemRepository(dbContext);
		}
		public object GetItems()
		{
			List<Item> itemsDB = itemRepo.GetAll().ToList();
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
