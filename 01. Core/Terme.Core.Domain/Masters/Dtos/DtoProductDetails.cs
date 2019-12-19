using System;
using System.Collections.Generic;
using System.Text;

namespace Terme.Core.Domain.Masters.Dtos
{
    public class DtoProductDetails
    {
 

        public string Description { get; set; }
        public long Price { get; set; }
        public long Discount { get; set; }
        public string MainPhoto { get; set; }
        public List<string> PhotoUrlCollection { get; set; }
        public string CategoryName { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public long CategoryId { get; set; }
        public string MasterFullName { get; set; }
        public long MasterId { get; set; }
    }
}
