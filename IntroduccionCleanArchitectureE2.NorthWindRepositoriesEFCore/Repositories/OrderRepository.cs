using IntroduccionCleanArchitectureE2.NorthWindEntities.Interfaces;
using IntroduccionCleanArchitectureE2.NorthWindEntities.POCOentites;
using IntroduccionCleanArchitectureE2.NorthWindEntities.Specifications;
using IntroduccionCleanArchitectureE2.NorthWindRepositoriesEFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE2.NorthWindRepositoriesEFCore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        readonly Context _context;
        public OrderRepository(Context context) => _context = context;
        
        public void Create(Order order)
        {
            _context.Add(order);
        }

        public IEnumerable<Order> GetOrderBySpecification(Specification<Order> specification)
        {
            var expresionDelegate = specification.Expression.Compile();
            return _context.Orders.Where(expresionDelegate);
        }
    }
}
