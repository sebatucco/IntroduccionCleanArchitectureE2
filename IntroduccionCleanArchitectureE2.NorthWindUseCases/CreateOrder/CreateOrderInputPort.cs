using IntroduccionCleanArchitectureE2.NorthWindUseCasesDTOs.CreateOrder;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE2.NorthWindUseCases.CreateOrder
{
    public class CreateOrderInputPort : CreateOrderParams, IRequest<int>
    {
    }
}
