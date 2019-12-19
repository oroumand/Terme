using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terme.Core.Domain.Orders.Entities;
using Terme.Core.Domain.Orders.Queries;
using Terme.Core.Domain.Orders.Repositories;

namespace Terme.Infrastructures.Data.SqlServer.Orders.Repositories
{
    public class OrderQueryRepository : IOrderQueryRepository
    {
        private readonly TermeDbContext termeDbContext;

        public OrderQueryRepository(TermeDbContext termeDbContext)
        {
            this.termeDbContext = termeDbContext;
        }
        public Order Select(OrderByIdQuery query)
        {
            return termeDbContext.Orders.
                Where(c => c.Id == query.OrderId).
                Include(c => c.OrderLines).
                ThenInclude(c=>c.MasterProduct).
                Include(c => c.Customer).FirstOrDefault();
        }
    }
}
