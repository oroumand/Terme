using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Orders.Commands;
using Terme.Core.Domain.Orders.Entities;
using Terme.Core.Domain.Orders.Repositories;
using Terme.Framework.Commands;
using Terme.Framework.Resources;

namespace Terme.Core.ApplicationServices.Orders.Commands
{
    public class SetTransactionCommandHandler : CommandHandler<SetTransactionCommand>
    {
        private readonly IOrderCommandRepository _orderCommandRepository;
        public SetTransactionCommandHandler(IResourceManager resourceManager,
            IOrderCommandRepository orderCommandRepository) : base(resourceManager)
        {
            _orderCommandRepository = orderCommandRepository;
        }

        public override CommandResult Handle(SetTransactionCommand command)
        {
            Order order = _orderCommandRepository.Find(command.OrderId);
            order.PaymentId = command.paymentId;
            _orderCommandRepository.Save();
            return Ok();
        }
    }
}
