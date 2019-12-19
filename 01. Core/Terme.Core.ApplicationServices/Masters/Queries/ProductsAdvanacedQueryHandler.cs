using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Masters.Dtos;
using Terme.Core.Domain.Masters.Entities;
using Terme.Core.Domain.Masters.Queries;
using Terme.Core.Domain.Masters.Repositories;
using Terme.Framework.Queries;

namespace Terme.Core.ApplicationServices.Masters.Queries
{
    public class ProductsAdvanacedQueryHandler : IQueryHandler<ProductsAdvanacedQuery, DtoProductsAdvanacedQuery>
    {
        private readonly IMasterProductQueryRepository masterProductQueryRepository;

        public ProductsAdvanacedQueryHandler(IMasterProductQueryRepository masterProductQueryRepository)
        {
            this.masterProductQueryRepository = masterProductQueryRepository;
        }
        public DtoProductsAdvanacedQuery Handle(ProductsAdvanacedQuery query)
        {
           return masterProductQueryRepository.GetNewestProductsLimited(query.number, query.TextSeach, query.MasterId, query.CategoryId, query.OrderBy, query.EnabledPaging, query.PageNumber,query.EnabledSorting);
        }
    }
}
