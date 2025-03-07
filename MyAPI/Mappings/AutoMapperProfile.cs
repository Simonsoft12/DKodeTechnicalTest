using AutoMapper;
using MyAPI.Entities.DTOs.Inventory;
using MyAPI.Entities.DTOs.Price;
using MyAPI.Entities.DTOs.Product;

namespace MyAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductDto, Entities.Product>()
                .ForMember(dest => dest.MainCategory, opt => opt.MapFrom(src => Data.Helpers.SupplierHelper.GetCategoryPart(src.Category, 0)))
                .ForMember(dest => dest.SubCategory, opt => opt.MapFrom(src => Data.Helpers.SupplierHelper.GetCategoryPart(src.Category, 1)))
                .ForMember(dest => dest.ChildCategory, opt => opt.MapFrom(src => Data.Helpers.SupplierHelper.GetCategoryPart(src.Category, 2)));

            CreateMap<InventoryDto, Entities.Inventory>()
                .ForMember(dest => dest.Qty, opt => opt.MapFrom(src => Data.Helpers.StringHelper.ParseNullableDecimal(src.Qty)))
                .ForMember(dest => dest.ShippingCost, opt => opt.MapFrom(src => Data.Helpers.StringHelper.ParseNullableDecimal(src.ShippingCost)));

            CreateMap<PriceDto, Entities.Price>()
                .ForMember(dest => dest.Column1, opt => opt.MapFrom(src => src.UniqueId))
                .ForMember(dest => dest.Column2, opt => opt.MapFrom(src => src.SKU))
                .ForMember(dest => dest.Column3, opt => opt.MapFrom(src => Data.Helpers.StringHelper.ParseNullableDecimal(src.NetPrice)))
                .ForMember(dest => dest.Column4, opt => opt.MapFrom(src => Data.Helpers.StringHelper.ParseNullableDecimal(src.PriceAfterDiscount)))
                .ForMember(dest => dest.Column5, opt => opt.MapFrom(src => Data.Helpers.StringHelper.ParseNullableDecimal(src.VATRate)))
                .ForMember(dest => dest.Column6, opt => opt.MapFrom(src => Data.Helpers.StringHelper.ParseNullableDecimal(src.NetPriceAfterDiscountForUnit)));
        }
    }
}
