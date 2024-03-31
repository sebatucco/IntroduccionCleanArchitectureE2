using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE2.NorthWindEntities.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangeAsync();
    }
}
