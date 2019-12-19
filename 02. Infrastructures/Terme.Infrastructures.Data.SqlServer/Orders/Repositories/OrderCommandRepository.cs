using Terme.Core.Domain.Orders.Entities;
using Terme.Core.Domain.Orders.Repositories;

namespace Terme.Infrastructures.Data.SqlServer.Orders.Repositories
{
    public class OrderCommandRepository : IOrderCommandRepository
    {
        private readonly TermeDbContext termeDbContext;

        public OrderCommandRepository(TermeDbContext termeDbContext)
        {
            this.termeDbContext = termeDbContext;
        }
        public void Add(Order order)
        {
            termeDbContext.Orders.Add(order);
            termeDbContext.SaveChanges();
        }

        public Order Find(long orderId)
        {
            return termeDbContext.Orders.Find(orderId);
        }

        public void Save()
        {
            termeDbContext.SaveChanges();
        }
    }
}
