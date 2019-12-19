using Terme.Core.Domain.Masters.Entities;
using Terme.Core.Domain.Masters.Queries;
using Terme.Core.Domain.Masters.Repositories;
using Terme.Framework.Queries;


namespace Terme.Core.ApplicationServices.Masters.Queries
{
    public class ProductByIdQueryHandler : IQueryHandler<ProductByIdQuery, MasterProduct>
    {
        private readonly IMasterProductQueryRepository masaterProductQueryRepository;

        public ProductByIdQueryHandler(IMasterProductQueryRepository masaterProductQueryRepository)
        {
            this.masaterProductQueryRepository = masaterProductQueryRepository;
        }
        public MasterProduct Handle(ProductByIdQuery query)
        {
            return masaterProductQueryRepository.GetProductById(query.ProductId);
        }
    }
}
