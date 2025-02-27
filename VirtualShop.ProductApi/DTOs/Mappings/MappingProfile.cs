using AutoMapper;
using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Map Category to CategoryDTO and back
        CreateMap<Category, CategoryDTO>().ReverseMap();

        // Map Product to ProductDTO
        CreateMap<Product, ProductDTO>()
            .ForMember(x => x.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(x => x.CategoryId, opt => opt.MapFrom(src => src.CategoryId));

        // Map ProductDTO to Product, ignoring the Category property.
        CreateMap<ProductDTO, Product>()
            .ForMember(dest => dest.Category, opt => opt.Ignore())
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));
    }
}