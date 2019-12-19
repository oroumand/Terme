using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Orders;
using Terme.Core.Domain.Orders.Entities;

namespace Terme.Infrastructures.Data.SqlServer.Orders.Configs
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(c => c.PaymentId).HasMaxLength(256);
        }
    }
}
