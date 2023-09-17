using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Dto.Seller;
using WebShop.Helper.Interfaces;
using WebShop.Infrastructure;
using WebShop.Interfaces;
using WebShop.Models;
using WebShop.Repository;

namespace WebShop.Services
{
	public class AdminService : IAdminService
	{
		private readonly IMapper _mapper;
		private readonly ITokenHelper _token;
		private readonly WebShopDbContext _dbContext;

		SellerRepository sellerRepo;

		public AdminService(IMapper mapper, ITokenHelper token, WebShopDbContext dbContext)
		{
			_mapper = mapper;
			_token = token;
			_dbContext = dbContext;

			sellerRepo = new SellerRepository(dbContext);
		}
		public object GetAllSellers()
		{
			List<Seller> sellerDB = sellerRepo.GetAll().ToList();
			List<SellerDto> sellerDto = new List<SellerDto>();

			foreach(Seller seller in sellerDB)
			{
				sellerDto.Add(new SellerDto(seller.Name, seller.Lastname, seller.Username, seller.Email, seller.Password, seller.Address, seller.BDay, seller.Verification));
			}
			SellerListDto sellerListDto = new SellerListDto() { Sellers = sellerDto };

			return sellerListDto;
		}
	}
}
