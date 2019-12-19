using Terme.Core.Domain.Masters.Entities;
using Terme.Framework.Domain;

namespace Terme.Core.Domain.Orders.Entities
{
    public class OrderLine : BaseEntity
    {
        public Order Order { get; set; }
        public long OrderId { get; set; }
        public long MasterProductsId { get; set; }
        public MasterProduct MasterProduct { get; set; }
        public int Count { get; set; }
        public long Price { get; set; }
        public long Discount { get; set; }
    }
}
