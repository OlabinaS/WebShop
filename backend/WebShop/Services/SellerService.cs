using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Dto;
using WebShop.Dto.Item;
using WebShop.Helper;
using WebShop.Helper.Interfaces;
using WebShop.Infrastructure;
using WebShop.Interfaces;
using WebShop.Models;
using WebShop.Repository;

namespace WebShop.Services
{
	public class SellerService : ISellerService
	{
		private readonly IMapper _mapper;
		private readonly WebShopDbContext _dbContext;
		private readonly ITokenHelper _tokenHelper;
		private readonly UserHelper _userHelper;
		private readonly SellerHelper _sellerHelper;

		SellerRepository sellerRepo;
        ItemRepository itemRepo;

		public SellerService(IMapper mapper, WebShopDbContext dbContext, ITokenHelper tokenHelper)
		{
			_mapper = mapper;
			_dbContext = dbContext;
            _tokenHelper = tokenHelper;

			_sellerHelper = new SellerHelper();
			_userHelper = new UserHelper(_dbContext);
			sellerRepo = new SellerRepository(_dbContext);
            itemRepo = new ItemRepository(_dbContext);
		}
		public IResultHelper GetAllItems(string token)
		{
            IResultHelper result;

            Seller seller = new Seller(_userHelper.UserByToken(token, _tokenHelper));

            if(seller == null)
			{
				result = new ResultHelper(false, "NotExist");
				return result;
			}
            else if(seller.Verification != Ver.Approved)
			{
				result = new ResultHelper(false, "NotApproved");
				return result;
			}

            List<Item> items = itemRepo.GetAll().ToList();
            items = _sellerHelper.GetItemsOfSeller(items, seller.Id);

            if (items.Count == 0)
                return new ResultHelper(false, "NoArticles");

			List<ItemDto> itemsDto = new List<ItemDto>();

			foreach(Item item in items)
			{
				itemsDto.Add(new ItemDto(item.Id, item.Name, item.Description, item.Quantity, item.Price));
			}

			ItemListDto itemListDto = new ItemListDto() { Items = itemsDto };
			result = new ResultHelper(true,"Done", itemListDto);
			return result;
		}
		public string AddItems(AddItemDto addItemDto, string token)
		{
			Seller seller = new Seller(_userHelper.UserByToken(token, _tokenHelper));

			if(seller == null)
				return "Seller doesn't exists";

			if (seller.Verification != Ver.Approved)
				return "Seller isn't approved by admin";

			if (addItemDto.Quantity <= 0)
				return "Quantity of items can't be less than 0";

			if (itemRepo.FindFirst(i => i.SellerId == seller.Id && i.Name == addItemDto.Name) != null)
				return "Seller already has an item with this name";

			Item item = _mapper.Map<Item>(addItemDto);
			item.SellerId = seller.Id;

			itemRepo.Add(item);

			_dbContext.SaveChanges();

			return "Ok";
		}

		
	}
}
