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
    public class AllMasterProductQueryHandler : IQueryHandler<AllMasterProductQuery, List<DtoProductBrief>>
    {
        private readonly IMasterProductQueryRepository masterProductQueryRepository;

        public AllMasterProductQueryHandler(IMasterProductQueryRepository masterProductQueryRepository )
        {
            this.masterProductQueryRepository = masterProductQueryRepository;
        }
        public List<DtoProductBrief> Handle(AllMasterProductQuery query)
        {
          return  masterProductQueryRepository.GetAll();
        }
    }
}
