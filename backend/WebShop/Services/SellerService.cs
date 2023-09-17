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
		private readonly ITokenHelper _tokenHelper;
		private readonly IDbHelper _dbHelper;
		private readonly UserHelper _userHelper;
		private readonly SellerHelper _sellerHelper;


		public SellerService(IMapper mapper, ITokenHelper tokenHelper, IDbHelper dbHelper)
		{
			_mapper = mapper;
            _tokenHelper = tokenHelper;
			_dbHelper = dbHelper;
			_sellerHelper = new SellerHelper();
			_userHelper = new UserHelper(_dbHelper);
		}
		public IResultHelper GetAllItems(string token)
		{
            IResultHelper result = _userHelper.UserByToken(token, _tokenHelper);
			Seller seller = null;

			if (result.Type == "seller")
				seller = (Seller)result.User;
			else
				return new ResultHelper(false, "NotExist");

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

            List<Item> items = _dbHelper.itemRepository.GetAll().ToList();
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
			IResultHelper result = _userHelper.UserByToken(token, _tokenHelper);
			Seller seller = null;

			if (result.Type == "seller")
				seller = (Seller)result.User;
			else
				return "Seller doesn't exists";

			if (seller == null)
				return "Seller doesn't exists";

			if (seller.Verification != Ver.Approved)
				return "Seller isn't approved by admin";

			if (addItemDto.Quantity <= 0)
				return "Quantity of items can't be less than 0";

			if (_dbHelper.itemRepository.FindFirst(i => i.SellerId == seller.Id && i.Name == addItemDto.Name) != null)
				return "Seller already has an item with this name";

			Item item = _mapper.Map<Item>(addItemDto);
			item.SellerId = seller.Id;

			_dbHelper.itemRepository.Add(item);

			_dbHelper.SaveChange();

			return "Ok";
		}

		
	}
}
