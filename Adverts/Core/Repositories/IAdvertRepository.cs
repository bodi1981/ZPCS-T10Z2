using Adverts.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adverts.Core.Repositories
{
    public interface IAdvertRepository
    {
        Task<IEnumerable<Advert>> GetAdverts(string title = null, int categoryId = 0, int productId = 0, int conditionId = 0, string userId = null);
        Task<Advert> GetAdvert(int advertId);
        Task<int> AddAdvert(Advert advert);
        Task RemoveAdvert(int advertId, string userId);
    }
}
