using AutoMapper;
using ProductShop.DTOS.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<UserImportDTO, User>();
            CreateMap<ProductImportDTO, Product>();
            CreateMap<CategoriesImportDTO, Category>();
            CreateMap<CategoryProductsImportDTO, CategoryProduct>();
        }
    }
}
