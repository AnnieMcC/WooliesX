using AutoMapper;
using WooliesX.Core.Models;
using WooliesX.Core.Resources;

namespace WooliesX.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Model >>> Resource
            CreateMap<User, UserResource>();
            CreateMap<Product, ProductResource>();
            CreateMap<ShopperHistory, ShopperHistoryResource>();

            // Resource >>> Model
            CreateMap<UserResource, User>();
            CreateMap<ProductResource, Product>();
        }
    }
}
