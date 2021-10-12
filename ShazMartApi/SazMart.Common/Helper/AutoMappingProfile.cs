using AutoMapper;
using SazMart.Common.Extentions;
using SazMart.DAL.ModelClass.DTO;
using SazMart.DAL.ModelClass.Entities;
using System.Linq;

namespace SazMart.Common.Helper
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<AppUser, UserDTO>()
                .ForMember(opt => opt.Age, des => des.MapFrom(x => x.DateOfBirth.CalculateAge()))
                 .ForMember(opt => opt.CountryName, des => des.MapFrom(x => x.Country.CountryName))
                 .ForMember(opt => opt.CityName, des => des.MapFrom(x => x.City.CityName))
                 .ForMember(opt => opt.PhotoUrl, des => des.MapFrom(x => x.AppUserPhoto.FirstOrDefault(p => p.IsMain).Url));


            CreateMap<Country,CountryDTO>();
            CreateMap<City,CityDTO>();
        }
    }
}
