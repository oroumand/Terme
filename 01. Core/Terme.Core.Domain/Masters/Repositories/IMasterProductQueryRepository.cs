using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Masters.Dtos;
using Terme.Core.Domain.Masters.Entities;
using Terme.Core.Domain.Masters.Enums;

namespace Terme.Core.Domain.Masters.Repositories
{
    public interface IMasterProductQueryRepository
    {
        List<DtoProductBrief> GetAll();
        DtoProductDetails GetProductDetails(long productId);
        MasterProduct GetProductById(long productId);
        DtoProductsAdvanacedQuery GetNewestProductsLimited(int number, string TextSeach, long MasterId, long CategoryId, EnumOrderByProduct orderBy, bool enabledPaging, int pageNumber, bool enabledSorting);
    }
}
