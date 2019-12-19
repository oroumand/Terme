using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Photos.Entities;
using Terme.Framework.Domain;

namespace Terme.Core.Domain.Masters.Entities
{
    public class MasterProductPhoto : BaseEntity
    {
        public MasterProduct MasterProducts { get; set; }
        public long MasterProductsId { get; set; }
        public Photo Photo { get; set; }
        public long PhotoId { get; set; }
    }
}
