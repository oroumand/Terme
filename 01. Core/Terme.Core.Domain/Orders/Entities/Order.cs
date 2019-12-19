using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Customers.Entities;
using Terme.Framework.Domain;

namespace Terme.Core.Domain.Orders.Entities
{
    public class Order : BaseEntity
    {
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public string PaymentId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }
}
