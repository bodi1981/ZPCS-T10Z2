using Adverts.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adverts.Core.Repositories
{
    public interface IConditionRepository
    {
        Task<IEnumerable<Condition>> GetConditions();
    }
}
