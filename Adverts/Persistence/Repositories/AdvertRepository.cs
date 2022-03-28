using Adverts.Core.Models.Domains;
using Adverts.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Adverts.Persistence.Repositories
{
    public class AdvertRepository : IAdvertRepository
    {
        private ApplicationDbContext _dbContext;
        public AdvertRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Advert>> GetAdverts(string title = null, int categoryId = 0, int productId = 0, int conditionId = 0, string userId = null)
        {
            var adverts = _dbContext.Adverts
                .Include(x => x.Product).AsQueryable();
            
            if(userId != null)
                adverts = adverts.Where(x => x.UserId == userId);

            if (categoryId != 0)
                adverts = adverts.Where(x => x.Product.CategoryId == categoryId);

            if (productId != 0)
                adverts = adverts.Where(x => x.ProductId == productId);

            if (conditionId != 0)
                adverts = adverts.Where(x => x.ConditionId == conditionId);

            if (!string.IsNullOrWhiteSpace(title))
                adverts = adverts.Where(x => x.Title.Contains(title));

            return await adverts.ToListAsync();
        }

        public async Task<Advert> GetAdvert(int advertId)
        {
            return await _dbContext.Adverts
                .Include(x => x.AdvertGalleries)
                .Include(x => x.Condition)
                .Include(x => x.Product)
                .Include(x => x.Product.Category).SingleAsync(x => x.Id == advertId);
        }

        public async Task<int> AddAdvert(Advert advert)
        {
            await _dbContext.Adverts.AddAsync(advert);
            await _dbContext.SaveChangesAsync();
            return advert.Id;
        }

        public async Task RemoveAdvert(int advertId, string userId)
        {
            var advertToRemove = await _dbContext.Adverts.SingleAsync(x => x.Id == advertId && x.UserId == userId);
            _dbContext.Adverts.Remove(advertToRemove);
        }
    }
}
