using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Masters.Entities;
using Terme.Core.Domain.Masters.Repositories;

namespace Terme.Infrastructures.Data.SqlServer.Masters.Repositories
{
    public class MasterProductCommandRepository : IMasterProductCommandRepository
    {

        public TermeDbContext termeDbContext { get; }

        public MasterProductCommandRepository(TermeDbContext termeDbContext)
        {
            this.termeDbContext = termeDbContext;
        }


        public void Add(MasterProduct masterProduct)
        {
            termeDbContext.Add(masterProduct);
            termeDbContext.SaveChanges();
        }
    }
}
