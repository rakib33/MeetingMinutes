using MeetingMinutes.Domain.Entities;
using MeetingMinutes.Infrastructure.Data;
using MeetingMinutes.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.Infrastructure.Repositories
{
    public class IndividualCustomerRepository : IIndividualCustomerRepository
    {
        private readonly ApplicationDbContext _db;

        public IndividualCustomerRepository(ApplicationDbContext db) => _db = db;

        public async Task<IQueryable<IndividualCustomer>> GetIndividualCustomersAsync()
        {
            return  _db.individualCustomers.AsQueryable().AsNoTracking().OrderBy(c => c.Name);
        }
    }
}
