using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE2.NorthWindUseCasesDTOs.CreateOrder
{
    public class CreateOrderDetailParams
    {
        public int ProductId { get; set; }
        public decimal UnidPrice { get; set; } 
        public short Quantity { get; set; }
    }
}
