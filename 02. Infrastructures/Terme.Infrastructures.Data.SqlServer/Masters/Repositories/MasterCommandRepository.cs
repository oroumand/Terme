using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Masters.Entities;
using Terme.Core.Domain.Masters.Repositories;

namespace Terme.Infrastructures.Data.SqlServer.Masters.Repositories
{
    public class MasterCommandRepository : IMasterCommandRepository
    {
        private readonly TermeDbContext termeDbContext;

        public MasterCommandRepository(TermeDbContext termeDbContext)
        {
            this.termeDbContext = termeDbContext;
        }
        public void Add(Master master)
        {
            termeDbContext.Masters.Add(master);
            termeDbContext.SaveChanges();
        }
    }
}
