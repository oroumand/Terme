using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Orders.Entities;
using Terme.Core.Domain.Orders.Queries;
using Terme.Core.Domain.Orders.Repositories;
using Terme.Framework.Queries;

namespace Terme.Core.ApplicationServices.Orders.Queries
{
    public class OrderByIdQueryHandler : IQueryHandler<OrderByIdQuery, Order>
    {
        private readonly IOrderQueryRepository orderQueryRepository;

        public OrderByIdQueryHandler(IOrderQueryRepository orderQueryRepository)
        {
            this.orderQueryRepository = orderQueryRepository;
        }
        public Order Handle(OrderByIdQuery query)
        {
            return orderQueryRepository.Select(query);
        }
    }
}
