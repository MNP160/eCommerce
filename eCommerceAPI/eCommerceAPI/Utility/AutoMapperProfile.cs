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
            CreateMap<Products, ProductDto>();
            CreateMap<ProductDto, Products>();

            CreateMap<Orders, OrdersDto>();
            CreateMap<OrdersDto, Orders>();

            CreateMap<Categories, CategoryDto>();
            CreateMap<CategoryDto, Categories>();

            CreateMap<ProductRequest, Products>();
            CreateMap<Products, ProductRequest>();


            CreateMap<OrderDetails, OrderDetailsDto>();
            CreateMap<OrderDetailsDto,OrderDetails>();

         

        }




    }
}
