using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE2.NorthWindUseCases.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderInputPort>
    {
        public CreateOrderValidator() 
        {
            RuleFor(c => c.CustomerId).NotEmpty()
                  .WithMessage("Debe proporcionar identificador decliente");
            
            RuleFor(c => c.ShipAddress).NotEmpty()
                .WithMessage("Debe proporcionar direccion de envio");

            RuleFor(c => c.ShipCity).NotEmpty().MinimumLength(3)
                .WithMessage("Debe proporcionar al menos 3 caracteres");

            RuleFor(c => c.ShipCountry).NotEmpty().MinimumLength(3)
                .WithMessage("Debe proporcionar al menos 3 caracteres");

            RuleFor(o => o.OrderDetails).Must(d => d != null && d.Any())
                .WithMessage("Debe especificar los productos de la orden");
        }   
    }
}
