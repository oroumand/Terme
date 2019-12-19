using Terme.Framework.Queries;

namespace Terme.Core.Domain.Orders.Queries
{
    public class OrderByIdQuery:IQuery
    {
        public long OrderId { get; set; }
    }
}
