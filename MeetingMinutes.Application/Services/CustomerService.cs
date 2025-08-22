using AutoMapper;
using MeetingMinutes.Application.DTOs;
using MeetingMinutes.Application.Interfaces;
using MeetingMinutes.Domain.Entities;
using MeetingMinutes.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly IIndividualCustomerRepository _individualCustomerRepository;

        public CustomerService(
            ICorporateCustomerRepository corporateCustomerRepository,
            IIndividualCustomerRepository individualCustomerRepository)
       {
            _corporateCustomerRepository = corporateCustomerRepository;
            _individualCustomerRepository = individualCustomerRepository;
        }
        public async Task<IEnumerable<CorporateCustomer>> GetCorporateCustomersAsync()
        {
            try
            {
                var result = await _corporateCustomerRepository.GetCorporateCustomersAsync();
                return await result.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception("An error occurred while retrieving corporate customers.", ex);
            }
        }

        public async Task<IEnumerable<IndividualCustomer>> GetIndividualCustomersAsync()
        {
            try
            {
                var result = await _individualCustomerRepository.GetIndividualCustomersAsync();                
                return await result.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception("An error occurred while retrieving individual customers.", ex);
            }
        }
    }
}
