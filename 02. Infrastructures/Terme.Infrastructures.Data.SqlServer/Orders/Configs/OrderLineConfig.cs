using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Orders;
using Terme.Core.Domain.Orders.Entities;

namespace Terme.Infrastructures.Data.SqlServer.Orders.Configs
{
    public class OrderLineConfig : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
        }
    }
}
