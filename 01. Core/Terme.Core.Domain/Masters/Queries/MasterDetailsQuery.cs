using System;
using System.Collections.Generic;
using System.Text;
using Terme.Framework.Queries;

namespace Terme.Core.Domain.Masters.Queries
{
    public class MasterDetailsQuery : IQuery
    {
        public long MasterId { get; set; }
    }
}
