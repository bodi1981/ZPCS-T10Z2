using Adverts.Core.Models.Domains;
using Adverts.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adverts.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(int id)
        {
            return await _dbContext.Products.Where(x => x.CategoryId == id).ToListAsync();
        }
    }
}
