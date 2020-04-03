using AutoMapper;
using eCommerceAPI.DTOs;
using eCommerceAPI.Extensions;
using eCommerceAPI.Models;
using eCommerceAPI.QueryParameters;
using farmersAPi.Interfaces;
using farmersAPi.Models;
using farmersAPi.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceAPI.Repositories
{
    public class OrderDetailsRepository : IRepository<OrderDetails, OrderDetailsDto>
    {

        private readonly APIContext _context;
        private IMapper _mapper;

        public OrderDetailsRepository(APIContext context, IMapper map)
        {
            _context = context;
            _mapper = map;
        }

       /* private async Task ReduceProductQuantityForOrder(OrderDetails order)
        {
          
           

            Products specificProduct = null;
           
            
                specificProduct = _context.Product.FirstOrDefault(x => x.ProductSKU == order.DetailSKU);
                switch (order.Size)
                {
                    case "S":
                        specificProduct.SCount -= order.DetailQuantity;
                        break;
                    case "M":
                        specificProduct.MCount -= order.DetailQuantity;
                        break;
                    case "L":
                        specificProduct.LCount -= order.DetailQuantity;
                        break;
                    case "XL":
                        specificProduct.XLCount -= order.DetailQuantity;
                        break;
                }
                _context.Product.Update(specificProduct);


                
            await _context.SaveChangesAsync();


        }*/


        public async Task<OrderDetails> Create(OrderDetails value)
        {
          //  await ReduceProductQuantityForOrder(value);
            _context.Set<OrderDetails>().Add(value);
            await _context.SaveChangesAsync();
            return value;
        }

        public async Task<OrderDetails> Delete(OrderDetails value)
        {
            _context.Set<OrderDetails>().Remove(value);
            await _context.SaveChangesAsync();
            return value;


        }
        public async Task<OrderDetails> Delete (int Id)
        {
            var entityToDelete = _context.OrderDetails.FirstOrDefault(x => x.DetailId == Id);
            if (entityToDelete != null)
            {
                _context.OrderDetails.Remove(entityToDelete);
                await _context.SaveChangesAsync();
                return entityToDelete;
            }
            else
            {
                return null;
            }
        }


        public async Task<PagedList<OrderDetailsDto>> Read(GenericParameters parameters)
        {

            return await Task.Run(()=>PagedList<OrderDetailsDto>.ToPagedList(FindAll(), parameters.PageNumber, parameters.PageSize));
        }

        public async Task<OrderDetailsDto> ReadById(int Id)
        {
            var entityToReturn = await _context.OrderDetails.FindAsync(Id);
            if (entityToReturn != null)
            {
                var dto = _mapper.Map<OrderDetailsDto>(entityToReturn);
                return dto;
            }
            else
            {
                return null;
            }
        }

        public async Task<OrderDetails> Update(OrderDetails value)
        {
            var editedEntity = _context.Set<OrderDetails>().FirstOrDefault(e => e.DetailId == value.DetailId);
            editedEntity = value;
            _context.Update(editedEntity);
            await _context.SaveChangesAsync();
            return value;

        }

        public IQueryable<OrderDetailsDto> FindAll()
        {
            var entities = _context.Set<OrderDetails>();
            var dtos = _mapper.Map<IList<OrderDetailsDto>>(entities);
            return dtos.AsQueryable();
        }

    }
}
