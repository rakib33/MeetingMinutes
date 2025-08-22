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
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) => _db = db;
        public async Task<IQueryable<Product>> GetProductsAsync()
        {
            return _db.products.AsQueryable().AsNoTracking().OrderBy(c => c.Name);
        }
    }
}
