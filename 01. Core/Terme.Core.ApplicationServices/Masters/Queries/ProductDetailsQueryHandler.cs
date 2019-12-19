using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Masters.Dtos;
using Terme.Core.Domain.Masters.Queries;
using Terme.Core.Domain.Masters.Repositories;
using Terme.Framework.Queries;


namespace Terme.Core.ApplicationServices.Masters.Queries
{
    public class ProductDetailsQueryHandler : IQueryHandler<ProductDetailsQuery, DtoProductDetails>
    {
        private readonly IMasterProductQueryRepository masaterProductQueryRepository;

        public ProductDetailsQueryHandler(IMasterProductQueryRepository masaterProductQueryRepository)
        {
            this.masaterProductQueryRepository = masaterProductQueryRepository;
        }
        public DtoProductDetails Handle(ProductDetailsQuery query)
        {
            return masaterProductQueryRepository.GetProductDetails(query.ProductId);
        }
    }
}
