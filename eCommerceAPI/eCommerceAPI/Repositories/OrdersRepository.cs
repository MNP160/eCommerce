using AutoMapper;
using eCommerceAPI.DTOs;
using eCommerceAPI.Extensions;
using eCommerceAPI.Models;
using eCommerceAPI.QueryParameters;
using farmersAPi.DTOs;
using farmersAPi.Interfaces;
using farmersAPi.Models;
using farmersAPi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceAPI.Repositories
{
    public class OrdersRepository :IRepository<Orders, OrdersDto>
    {
        private readonly APIContext _context;
        private IMapper _mapper;

        public OrdersRepository(APIContext context, IMapper map)
        {
            _context = context;
            _mapper = map;
        }


        private  async Task ReduceProductQuantityForOrder(Orders order)
        {
            var orderItems = _context.OrderDetails.Where(x=>x.OrderId==order.Id);
            var products = _context.Product.ToList();
            
            Products specificProduct = null;
            foreach(var item in orderItems)
            {
                specificProduct = products.FirstOrDefault(x => x.ProductSKU == item.DetailSKU);
                switch (order.Size)
                {
                    case "S":
                        specificProduct.SCount -= item.DetailQuantity;
                        break;
                    case "M":
                        specificProduct.MCount -= item.DetailQuantity;
                        break;
                    case "L":
                        specificProduct.LCount -= item.DetailQuantity;
                        break;
                    case "XL":
                        specificProduct.XLCount -= item.DetailQuantity;
                        break;
                }
                _context.Product.Update(specificProduct);

              
                specificProduct = null;
            }
            await _context.SaveChangesAsync();

                     
        }

      


        public async Task<Orders> Create(Orders value)
        {
            await ReduceProductQuantityForOrder(value);
            _context.Set<Orders>().Add(value);
            await _context.SaveChangesAsync();
            return value;
        }

        public async Task<Orders> Delete(Orders value)
        {
            _context.Set<Orders>().Remove(value);
            await _context.SaveChangesAsync();
            return value;


        }
        public async Task<Orders> Delete(int Id)
        {
            var entityToDelete = _context.Orders.FirstOrDefault(x => x.Id == Id);
            if (entityToDelete != null)
            {
                _context.Orders.Remove(entityToDelete);
                await _context.SaveChangesAsync();
                return entityToDelete;
            }
            else
            {
                return null;
            }
        }


        public async Task<PagedList<OrdersDto>> Read(GenericParameters parameters)
        {
            //test this cause it probably breaks
            return  await Task.Run(()=>PagedList<OrdersDto>.ToPagedList(FindAll(), parameters.PageNumber, parameters.PageSize));
        }

        public async Task<OrdersDto> ReadById(int Id)
        {
            var entityToReturn = await _context.Orders.FindAsync(Id);
            if (entityToReturn != null)
            {
                var dto = _mapper.Map<OrdersDto>(entityToReturn);
                return dto;
            }
            else
            {
                return null;
            }
        }

        public async Task<Orders> Update(Orders value)
        {
            var editedEntity = _context.Set<Orders>().FirstOrDefault(e => e.OrderSKU == value.OrderSKU);
            if (editedEntity != null)
            {
                editedEntity.Address = value.Address;
                editedEntity.City = value.City;
                editedEntity.IsCashPayment = value.IsCashPayment;
                editedEntity.IsOrderComplete = value.IsOrderComplete;
                editedEntity.OrderDate = value.OrderDate;
                editedEntity.OrderEmail = value.OrderEmail;
                editedEntity.OrderZipCode = value.OrderZipCode;
                editedEntity.Phone = value.Phone;
                editedEntity.Size = value.Size;
                editedEntity.TotalAmount = value.TotalAmount;
               

                _context.Update(editedEntity);
                await _context.SaveChangesAsync();
                return value;
            }
            else
            {
                return null;
            }

        }

        public IQueryable<OrdersDto> FindAll()
        {
            var entities = _context.Set<Orders>();
            var dtos = _mapper.Map<IList<OrdersDto>>(entities);
            return dtos.AsQueryable();
        }




    }
}
