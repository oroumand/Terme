using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Masters.Dtos;
using Terme.Core.Domain.Masters.Entities;
using Terme.Core.Domain.Masters.Queries;
using Terme.Core.Domain.Masters.Repositories;
using Terme.Framework.Queries;

namespace Terme.Core.ApplicationServices.Masters.Queries
{
  public  class MasterDetailsQueryHandler : IQueryHandler<MasterDetailsQuery, DtoMasterDetails>
    {
        private readonly IMasterQueryRepository masterQueryRepository;

        public MasterDetailsQueryHandler(IMasterQueryRepository masterQueryRepository)
        {
            this.masterQueryRepository = masterQueryRepository;
        }
 
        public DtoMasterDetails Handle(MasterDetailsQuery query)
        {
            return masterQueryRepository.GetMasterDetails(query.MasterId);
        }
    }
}
