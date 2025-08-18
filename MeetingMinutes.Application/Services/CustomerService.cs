using MeetingMinutes.Application.DTOs;
using MeetingMinutes.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.Application.Services
{
    public class CustomerService : ICustomerService
    {
        public Task<IEnumerable<CorporateCustomerDto>> GetCorporateCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IndividualCustomerDto>> GetIndividualCustomersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
