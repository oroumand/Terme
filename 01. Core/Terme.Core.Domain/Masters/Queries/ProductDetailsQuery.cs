using System;
using System.Collections.Generic;
using System.Text;
using Terme.Framework.Queries;

namespace Terme.Core.Domain.Masters.Queries
{
    public class ProductDetailsQuery : IQuery
    {
        public long ProductId { get; set; }
    }

    public class ProductByIdQuery : IQuery
    {
        public long ProductId { get; set; }
    }

}
