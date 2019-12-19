using System;
using System.Collections.Generic;
using System.Text;

namespace Terme.Core.Domain.Masters.Dtos
{
    public class DtoProductBrief
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public long Price { get; set; }
        public long Discount { get; set; }
        public string PhotoUrl { get; set; }
        public string MasterFullName { get; set; }
        public long MasterId { get; set; }
    }
}
