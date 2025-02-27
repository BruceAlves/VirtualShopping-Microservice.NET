using AutoMapper;
using VirtualShopping.Product.Models;
namespace VirtualShopping.Product.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Models.Product, ProductDTO>().ReverseMap();
    }
}
