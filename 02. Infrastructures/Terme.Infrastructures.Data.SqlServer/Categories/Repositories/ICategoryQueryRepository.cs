using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Terme.Core.Domain.Categories.Entities;
using Terme.Core.Domain.Categories.Repositories;

namespace Terme.Infrastructures.Data.SqlServer.Categories.Repositories
{
    public class CategoryQueryRepository : ICategoryQueryRepository
    {
        private readonly TermeDbContext _termeDbContext;

        public CategoryQueryRepository(TermeDbContext termeDbContext)
        {
            this._termeDbContext = termeDbContext;
        }

        public List<Category> GetAll()
        {
            return _termeDbContext.Categories.Include(c => c.Photo).Include(c => c.Children).ThenInclude(c => c.Photo).Where(c => !c.ParentId.HasValue).ToList();
        }

        public List<Category> GetParentCategories()
        {
            return _termeDbContext.Categories.Where(c => !c.ParentId.HasValue).ToList();
        }
    }
}
