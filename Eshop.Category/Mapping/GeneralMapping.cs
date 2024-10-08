﻿using AutoMapper;
using Eshop.Category.Dtos.CategoryDtos;
using Eshop.Category.Dtos.ProductDetailDtos;
using Eshop.Category.Dtos.ProductDtos;
using Eshop.Category.Dtos.ProductImageDtos;
using Eshop.Category.Entities;

namespace Eshop.Category.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping() 
        { 
            CreateMap<Category.Entities.Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category.Entities.Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category.Entities.Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category.Entities.Category, GetByIdCategoryDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();

            CreateMap<Category.Entities.ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<Category.Entities.ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<Category.Entities.ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<Category.Entities.ProductDetail, GetByIdProductDetailDto>().ReverseMap();

            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();
            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
        }
    }
}
