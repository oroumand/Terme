using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Photos.Entities;
using Terme.Framework.Domain;

namespace Terme.Core.Domain.Categories.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public Category Parent { get; set; }
        public List<Category> Children { get; set; }
        public Photo Photo { get; set; }
        public long PhotoId { get; set; }
    }
}
