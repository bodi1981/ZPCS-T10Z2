using Adverts.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adverts.Core
{
    public interface IUnitOfWork
    {
        IAdvertRepository Advert { get; set; }
        ICategoryRepository Category { get; set; }
        IConditionRepository Condition { get; set; }
        IProductRepository Product { get; set; }
        Task Complete();
    }
}
