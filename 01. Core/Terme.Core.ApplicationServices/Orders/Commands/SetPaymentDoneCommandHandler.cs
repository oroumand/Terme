using System;
using Terme.Core.Domain.Orders.Commands;
using Terme.Core.Domain.Orders.Entities;
using Terme.Core.Domain.Orders.Repositories;
using Terme.Framework.Commands;
using Terme.Framework.Resources;

namespace Terme.Core.ApplicationServices.Orders.Commands
{
    public class SetPaymentDoneCommandHandler : CommandHandler<SetPaymentDoneCommand>
    {
        private readonly IOrderCommandRepository _orderCommandRepository;
        public SetPaymentDoneCommandHandler(IResourceManager resourceManager,
            IOrderCommandRepository orderCommandRepository) : base(resourceManager)
        {
            _orderCommandRepository = orderCommandRepository;
        }

        public override CommandResult Handle(SetPaymentDoneCommand command)
        {
            Order order = _orderCommandRepository.Find(command.OrderId);
            order.PaymentDate = DateTime.Now;
            _orderCommandRepository.Save();
            return Ok();
        }
    }
}
