using AutoMapper;
using eCommerceAPI.Extensions;
using eCommerceAPI.QueryParameters;
using farmersAPi.DTOs;
using farmersAPi.Interfaces;
using farmersAPi.Models;
using farmersAPi.Utility;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Repositories
{
    public class ProductRepository :IRepository<Products, ProductDto>
    { 
        private APIContext _context;
        private IMapper _mapper;
        private IImageHandler _handler;
        public ProductRepository(APIContext context, IMapper map, IImageHandler handler) 
        {
            _context = context;
            _mapper = map;
            _handler = handler;
        }

        public async Task<Products> Create(Products value)
        {
           _context.Add(value);
            await _context.SaveChangesAsync();
            return value;
        }

        public async Task<Products> Create(ProductRequest value, IFormFile file)
        {

            var product = _mapper.Map<Products>(value);
            var path = await _handler.UploadImage(file);
            product.ImagePath = path;
            _context.Product.Add(product);
           
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Products> Delete(Products value)
        {
            _context.Set<Products>().Remove(value);
            await _context.SaveChangesAsync();
            return value;


        }
        public async Task<Products> Delete(int Id)
        {
            var entityToDelete = _context.Product.FirstOrDefault(x => x.Id == Id);
            if (entityToDelete != null)
            {
                _context.Product.Remove(entityToDelete);
                await _context.SaveChangesAsync();
                return entityToDelete;
            }
            else
            {
                return null;
            }
        }


        public async Task<PagedList<ProductDto>> Read(GenericParameters parameters)
        {

            return await Task.Run(()=>PagedList<ProductDto>.ToPagedList(FindAll(), parameters.PageNumber, parameters.PageSize));
        }

        public async Task<ProductDto> ReadById(int Id)
        {
            var entityToReturn = await _context.Product.FindAsync(Id);
            if (entityToReturn != null)
            {
                var dto = _mapper.Map<ProductDto>(entityToReturn);
                return dto;
            }
            else
            {
                return null;
            }
        }

        public async Task<Products> Update(Products value)
        {
            var editedEntity = _context.Set<Products>().FirstOrDefault(e => e.ProductSKU == value.ProductSKU);
           if(editedEntity != null)
            {
                editedEntity.Name = value.Name;
                editedEntity.OriginalPrice = value.OriginalPrice;
               
                editedEntity.ShortDescription = value.ShortDescription;
              
                editedEntity.LongDescription = value.LongDescription;
                
                editedEntity.IsLive = value.IsLive;
                
                _context.Update(editedEntity);
                await _context.SaveChangesAsync();
                return value;
            }

            return null;
        }

        public IQueryable<ProductDto> FindAll()
        {
            var entities = _context.Set<Products>();
            var dtos = _mapper.Map<IList<ProductDto>>(entities);
            return dtos.AsQueryable();
        }

    }
}

