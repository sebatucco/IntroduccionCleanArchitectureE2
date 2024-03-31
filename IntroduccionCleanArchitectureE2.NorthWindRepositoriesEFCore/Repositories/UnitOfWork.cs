using IntroduccionCleanArchitectureE2.NorthWindEntities.Interfaces;
using IntroduccionCleanArchitectureE2.NorthWindRepositoriesEFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE2.NorthWindRepositoriesEFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly Context _context;

        public UnitOfWork(Context context)
        {
            _context = context;
        }
        public Task<int> SaveChangeAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
