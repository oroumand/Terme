using Terme.Core.Domain.Orders.Entities;
using Terme.Core.Domain.Orders.Queries;

namespace Terme.Core.Domain.Orders.Repositories
{
    public interface IOrderQueryRepository
    {
        Order Select(OrderByIdQuery query);
    }
}
