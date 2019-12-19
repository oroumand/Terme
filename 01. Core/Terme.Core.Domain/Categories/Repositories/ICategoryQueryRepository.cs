using System.Collections.Generic;
using Terme.Core.Domain.Categories.Entities;

namespace Terme.Core.Domain.Categories.Repositories
{
    public interface ICategoryQueryRepository
    {
        List<Category> GetParentCategories();
        List<Category> GetAll();
    }
}
