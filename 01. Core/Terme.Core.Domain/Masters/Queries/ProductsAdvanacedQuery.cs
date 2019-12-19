using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Masters.Enums;
using Terme.Framework.Queries;

namespace Terme.Core.Domain.Masters.Queries
{
    public class ProductsAdvanacedQuery : IQuery
    {
        public int number { get; set; }
        public EnumOrderByProduct OrderBy { get; set; }
        public bool EnabledPaging { get; set; } = false;
        public bool EnabledSorting { get; set; } = false;
        public int PageNumber { get; set; }
        public string TextSeach { get; set; } = "";
        public long MasterId { get; set; }
        public long CategoryId { get; set; }

    }
}


