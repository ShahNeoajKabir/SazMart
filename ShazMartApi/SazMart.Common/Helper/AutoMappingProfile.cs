using AutoMapper;
using SazMart.DAL.ModelClass.DTO;
using SazMart.DAL.ModelClass.Entities;

namespace SazMart.Common.Helper
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<AppUserDTO,AppUser>();
            CreateMap<Country,CountryDTO>();
            CreateMap<City,CityDTO>();
        }
    }
}
