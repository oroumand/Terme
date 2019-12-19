using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Categories.Entities;
using Terme.Core.Domain.Photos.Entities;
using Terme.Framework.Domain;

namespace Terme.Core.Domain.Masters.Entities
{
    public class MasterProduct : BaseEntity
    {
        public Master Master { get; set; }
        public long MasterId { get; set; }
        public Category Category { get; set; }
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public long Discount { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public List<MasterProductPhoto> masterProductPhotos { get; set; }

        public Photo MainPhoto { get; set; }

    }
}
