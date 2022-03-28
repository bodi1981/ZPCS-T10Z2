using Adverts.Core.Models.Domains;
using Adverts.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adverts.Persistence.Repositories
{
    public class ConditionRepository : IConditionRepository
    {
        private ApplicationDbContext _dbContext;
        public ConditionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Condition>> GetConditions()
        {
            return await _dbContext.Conditions.ToListAsync();
        }
    }
}
