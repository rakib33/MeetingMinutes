using AutoMapper;
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
    public class CorporateCustomerRepository : ICorporateCustomerRepository
    {     
        private readonly ApplicationDbContext _db;

        public CorporateCustomerRepository(ApplicationDbContext db) => _db = db;

        public async Task<IQueryable<CorporateCustomer>> GetCorporateCustomersAsync()
        {
            return _db.corporateCustomers.AsQueryable().AsNoTracking().OrderBy(c => c.Name);
        }
    }
}
