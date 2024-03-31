using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE2.NorthWindRepositoriesEFCore.DataContext
{
    class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<Context>();
            optionBuilder.UseSqlServer("Data Source = DESKTOP-0KJ2PDV; Initial Catalog=IntroduccionCleanArchitectureE2; Integrated Security=true; TrustServerCertificate=True");
            return new Context (optionBuilder.Options);
        }
    }
}
