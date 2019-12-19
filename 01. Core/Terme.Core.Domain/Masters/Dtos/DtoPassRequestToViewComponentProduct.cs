using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Masters.Enums;

namespace Terme.Core.Domain.Masters.Dtos
{
    public class DtoPassRequestToViewComponentProduct
    {
        public int CurrentPage { get; set; }
        public EnumOrderByProduct OrderByProduct { get; set; }
        public string TextSeach { get; set; }
        public long MasterId { get; set; }
        public long CategoryId { get; set; }
    }
}
