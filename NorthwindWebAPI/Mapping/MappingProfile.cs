using AutoMapper;
using Northwind.Contracts.Dto.Authencation;
using Northwind.Contracts.Dto.Category;
using Northwind.Contracts.Dto.Order;
using Northwind.Contracts.Dto.OrderDetail;
using Northwind.Contracts.Dto.Product;
using Northwind.Contracts.Dto.Supplier;
using Northwind.Domain.Models;

namespace Northwind.WebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryForCreateDto>().ReverseMap();

            CreateMap<Supplier, SupplierDto>().ReverseMap();
            CreateMap<Supplier, SupplierForCreateDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductPhotoGroupDto>().ReverseMap();
            CreateMap<Product, ProductForCreateDto>().ReverseMap();

            CreateMap<ProductPhoto, ProductPhotoDto>().ReverseMap();
            CreateMap<ProductPhoto, ProductPhotoGroupDto>().ReverseMap();
            CreateMap<ProductPhoto, ProductPhotoCreateDto>().ReverseMap();

            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailForCreateDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, OrderForCreateDto>().ReverseMap();
            CreateMap<UserRegistrationDto, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));

            CreateMap<UserLoginDto,User>().ReverseMap();


            /*CreateMap<ProductPhoto, ProductPhotoGroupDto>()
                .ForPath(p => p.productDto.ProductName, pp => pp.MapFrom(p => p.PhotoProduct.ProductName))
                .ForPath(p => p.productDto.Supplier.CompanyName, pp => pp.MapFrom(p => p.PhotoProduct.Supplier.CompanyName))
                .ForPath(p => p.productDto.Category.CategoryName, pp => pp.MapFrom(p => p.PhotoProduct.Category.CategoryName))
                .ForPath(p => p.productDto.QuantityPerUnit, pp => pp.MapFrom(p => p.PhotoProduct.QuantityPerUnit))
                .ForPath(p => p.productDto.UnitPrice, pp => pp.MapFrom(p => p.PhotoProduct.UnitPrice))
                .ForPath(p => p.productDto.UnitsInStock, pp => pp.MapFrom(p => p.PhotoProduct.UnitsInStock))
                .ForPath(p => p.productDto.Discontinued, pp => pp.MapFrom(p => p.PhotoProduct.Discontinued))

                .ReverseMap();*/
        }
    }
}
