using System.Collections.Generic;
using Terme.Core.Domain.Categories.Entities;
using Terme.Core.Domain.Categories.Queries;
using Terme.Core.Domain.Categories.Repositories;
using Terme.Framework.Queries;

namespace Terme.Core.ApplicationServices.Categories.Queries
{
    public class ParentCategoryQueryHandler : IQueryHandler<ParentCategoryQuery, List<Category>>
    {
        private readonly ICategoryQueryRepository categoryQueryRepository;

        public ParentCategoryQueryHandler(ICategoryQueryRepository categoryQueryRepository)
        {
            this.categoryQueryRepository = categoryQueryRepository;
        }
        public List<Category> Handle(ParentCategoryQuery query)
        {
            return categoryQueryRepository.GetParentCategories();
        }
    }
}
