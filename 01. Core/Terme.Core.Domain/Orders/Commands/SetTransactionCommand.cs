using System;
using System.Collections.Generic;
using System.Text;
using Terme.Framework.Commands;

namespace Terme.Core.Domain.Orders.Commands
{
    public class SetTransactionCommand:ICommand
    {
        public long OrderId { get; set; }
        public string paymentId{ get; set; }
    }
}
