using Adverts.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adverts.Core.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsByCategory(int id);
    }
}
