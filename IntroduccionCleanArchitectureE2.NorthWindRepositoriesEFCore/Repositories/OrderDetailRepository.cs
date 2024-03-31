using IntroduccionCleanArchitectureE2.NorthWindEntities.Interfaces;
using IntroduccionCleanArchitectureE2.NorthWindEntities.POCOentites;
using IntroduccionCleanArchitectureE2.NorthWindRepositoriesEFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE2.NorthWindRepositoriesEFCore.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        readonly Context _context;
        public OrderDetailRepository(Context context)
        {
            _context = context;     
        }
        public void Create(OrderDetail orderDetail)
        {
            _context.Add(orderDetail);
        }
    }
}
