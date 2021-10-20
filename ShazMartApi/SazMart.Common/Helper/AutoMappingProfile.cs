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
                 .ForMember(opt => opt.PhotoUrl, des => des.MapFrom(x => x.AppUserPhoto.FirstOrDefault(p => p.IsMain).Url))
                 .ForMember(opt => opt.Gender, des => des.MapFrom(x => x.Gender));


            CreateMap<Country,CountryDTO>();
            CreateMap<City,CityDTO>();
            CreateMap<AppUserDTO,AppUser>();

            CreateMap<Product, ProductDTO>()
                .ForMember(x => x.BrandName, p => p.MapFrom(t => t.Brand.BrandName))
                .ForMember(x => x.CategoriesName, p => p.MapFrom(t => t.SubCategories.Categories.Name))
                .ForMember(x => x.SubCategoriesName, p => p.MapFrom(t => t.SubCategories.SubCategoriesName))
                .ForMember(x => x.PhotoUrl, p => p.MapFrom(x => x.ProductPhoto.FirstOrDefault(t => t.IsMain).Url));


            CreateMap<ProductPhoto, ProductPhotoDTO>();

            CreateMap<Categories, CategoriesDTO>()
                .ForMember(opt => opt.CategoriesName, dest => dest.MapFrom(x => x.Name))
                .ForMember(opt => opt.SubCategories, dest => dest.MapFrom(x => x.SubCategories.FirstOrDefault().SubCategoriesName))
                .ForMember(opt => opt.SubCategoriesDTO, dest => dest.MapFrom(x => x.SubCategories));
            CreateMap<SubCategories, SubCategoriesDTO>();

            CreateMap<ColorDTO, Colors>();
            CreateMap<Colors, ColorDTO>()
                .ForMember(s => s.ProductName,
                d => d.MapFrom(t => t.ProductColor.
                  FirstOrDefault().Product.ProductName));
        }
    }
}
