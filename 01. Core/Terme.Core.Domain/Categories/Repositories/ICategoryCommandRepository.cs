using System;
using System.Text;
using Terme.Core.Domain.Categories.Entities;

namespace Terme.Core.Domain.Categories.Repositories
{
    public interface ICategoryCommandRepository
    {
        void Add(Category category);
    }
}
