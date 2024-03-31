using IntroduccionCleanArchitectureE2.NorthWindEntities.Exceptions;
using IntroduccionCleanArchitectureE2.NorthWindEntities.Interfaces;
using IntroduccionCleanArchitectureE2.NorthWindEntities.POCOentites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE2.NorthWindUseCases.CreateOrder
{
    public class CreateOrderInteractor : IRequestHandler<CreateOrderInputPort, int>
    {
        readonly IOrderRepository _orderRepository;
        readonly IOrderDetailRepository _orderDetailRepository;
        readonly IUnitOfWork _unitOfWork;

        public CreateOrderInteractor(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork)
        {
            _orderDetailRepository = orderDetailRepository;
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateOrderInputPort request, CancellationToken cancellationToken)
        {
            Order order = new Order
            {
                CustomerId = request.CustomerId,
                OrderDate = DateTime.Now,
                ShipAddress = request.ShipAddress,
                ShipCity = request.ShipCity,
                ShipCountry = request.ShipCountry,
                ShipPostalCode = request.ShipPostalCode,
                ShippingType = NorthWindEntities.Enums.Shippingtype.Road,
                DiscountType = NorthWindEntities.Enums.DiscountType.Percentage,
                Discount = 10
            };

            _orderRepository.Create(order);
            foreach (var item in request.OrderDetails)
            {
                _orderDetailRepository.Create(
                     new OrderDetail
                     {
                         Order = order,
                         ProductId = item.ProductId,
                         UnitPrice = item.UnidPrice,
                         Quantity = item.Quantity

                     });
            }
            try
            {
                await _unitOfWork.SaveChangeAsync();
            }
            catch (Exception ex)
            {

                throw new GeneralExceptions("Error al crear la orden", ex.Message);
            }
            return order.Id;
        }
    }
}
