using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Categories.Entities;
using Terme.Core.Domain.Categories.Queries;
using Terme.Core.Domain.Categories.Repositories;
using Terme.Framework.Queries;

namespace Terme.Core.ApplicationServices.Categories.Queries
{
    public class AllCategoryQueryHandler : IQueryHandler<AllCategoryQuery, List<Category>>
    {
        private readonly ICategoryQueryRepository categoryQueryRepository;

        public AllCategoryQueryHandler(ICategoryQueryRepository categoryQueryRepository)
        {
            this.categoryQueryRepository = categoryQueryRepository;
        }
        public List<Category> Handle(AllCategoryQuery query)
        {
            return categoryQueryRepository.GetAll();
        }
    }
}
