using AutoMapper;
using eCommerceAPI.DTOs;
using eCommerceAPI.Models;
using farmersAPi.DTOs;
using farmersAPi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Utility
{
    public  class AutoMapperProfile :Profile
    {

        public AutoMapperProfile()
        {
           
            CreateMap<UserDto, Users>();
            CreateMap<RegisterModel, Users>();
            CreateMap<Users, UserDto>();
            CreateMap<Users, RegisterModel>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Orders, OrdersDto>();
            CreateMap<OrdersDto, Orders>();

            CreateMap<Cathegory, CathegoryDto>();
            CreateMap<CathegoryDto, Cathegory>();

            CreateMap<ProductModel, Product>();
            CreateMap<Product, ProductModel>();


            CreateMap<OrderItems, OrderItemsDto>();
            CreateMap<OrderItemsDto,OrderItems>();

            CreateMap<Users, ProductUserDto>();
            CreateMap<ProductUserDto, Users>();

            CreateMap<Product, OrderItemProductDto>();
            CreateMap<OrderItemProductDto, Product>();

        }




    }
}
