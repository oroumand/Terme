using Terme.Framework.Commands;

namespace Terme.Core.Domain.Orders.Commands
{
    public class SetPaymentDoneCommand : ICommand
    {
        public long OrderId { get; set; }
    }
}
