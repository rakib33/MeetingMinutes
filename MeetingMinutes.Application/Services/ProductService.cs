using AutoMapper;
using MeetingMinutes.Application.DTOs;
using MeetingMinutes.Application.Interfaces;
using MeetingMinutes.Domain.Entities;
using MeetingMinutes.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            try
            {
                var result = await _productRepository.GetProductsAsync();
                return await result.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception("An error occurred while retrieving corporate customers.", ex);
            }
        }
    }
}
