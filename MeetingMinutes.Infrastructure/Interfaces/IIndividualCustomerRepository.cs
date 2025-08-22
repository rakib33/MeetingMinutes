using MeetingMinutes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.Infrastructure.Interfaces
{
    public interface IIndividualCustomerRepository
    {
       Task<IQueryable<IndividualCustomer>> GetIndividualCustomersAsync();
    }
}
