using AutoMapper;
using SazMart.Common.Extentions;
using SazMart.DAL.ModelClass.DTO;
using SazMart.DAL.ModelClass.ViewModel;
using System.Linq;

namespace SazMart.Common.Helper
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<BrandViewModel, Brand>();
            CreateMap<Brand, BrandViewModel>();
        }
    }
}
