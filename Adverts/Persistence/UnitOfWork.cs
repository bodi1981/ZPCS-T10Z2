using Adverts.Core;
using Adverts.Core.Repositories;
using Adverts.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adverts.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Advert = new AdvertRepository(dbContext);
            Category = new CategoryRepository(dbContext);
            Condition = new ConditionRepository(dbContext);
            Product = new ProductRepository(dbContext);
        }

        public IAdvertRepository Advert { get; set; }
        public ICategoryRepository Category { get; set; }
        public IConditionRepository Condition { get; set; }
        public IProductRepository Product { get; set; }
        public async Task Complete()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
