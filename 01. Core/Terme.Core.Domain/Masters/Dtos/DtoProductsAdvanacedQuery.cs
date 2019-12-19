using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Masters.Enums;

namespace Terme.Core.Domain.Masters.Dtos
{
    public class DtoProductsAdvanacedQuery
    {
        //------List found Products----------//
        public List<DtoProductBrief> DtoProductBriefCollection { get; set; }
        //---------Request parameters by End User------------//
        public int CountPages { get; set; }
        public int CurrentPage { get; set; }
        public EnumOrderByProduct OrderByProduct { get; set; }
        public string TextSeach { get; set; }
        public long MasterId { get; set; }
        public long CategoryId { get; set; }

        //--------------UI Designer Filled before, for Customizing View------------------//
        public string Title { get; set; }
        public EnumDisplayModeProducts DisplayModeProducts { get; set; }
        public bool EnabledPaging { get; set; }
        public bool EnabledSorting { get; set; }
    }
}
