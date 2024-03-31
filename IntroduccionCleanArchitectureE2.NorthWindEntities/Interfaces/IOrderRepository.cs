using IntroduccionCleanArchitectureE2.NorthWindEntities.POCOentites;
using IntroduccionCleanArchitectureE2.NorthWindEntities.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE2.NorthWindEntities.Interfaces
{
    public interface IOrderRepository
    {
        void Create(Order order);
        IEnumerable<Order> GetOrderBySpecification(Specification<Order> specification);
    }
}
