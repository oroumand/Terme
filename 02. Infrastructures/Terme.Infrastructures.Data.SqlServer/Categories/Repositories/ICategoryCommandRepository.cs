using System;
using System.Text;
using Terme.Core.Domain.Categories.Entities;
using Terme.Core.Domain.Categories.Repositories;

namespace Terme.Infrastructures.Data.SqlServer.Categories.Repositories
{
    public class CategoryCommandRepository : ICategoryCommandRepository
    {
        private readonly TermeDbContext _termeDbContext;

        public CategoryCommandRepository(TermeDbContext termeDbContext)
        {
            _termeDbContext = termeDbContext;
        }
        public void Add(Category category)
        {
            _termeDbContext.Add(category);
            _termeDbContext.SaveChanges();
        }
    }
}
