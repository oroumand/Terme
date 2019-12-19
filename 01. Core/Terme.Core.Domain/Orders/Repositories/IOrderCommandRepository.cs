using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Orders.Entities;

namespace Terme.Core.Domain.Orders.Repositories
{
    public interface IOrderCommandRepository
    {
        void Add(Order order);
        Order Find(long orderId);
        void Save();
    }
}
