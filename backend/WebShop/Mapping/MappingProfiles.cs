using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebShop.Dto;
using WebShop.Models;

namespace WebShop.Mapping
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<RegistrationDto, User>();
			CreateMap<RegistrationDto, Customer>();
			CreateMap<RegistrationDto, Seller>();




		}
	}
}
