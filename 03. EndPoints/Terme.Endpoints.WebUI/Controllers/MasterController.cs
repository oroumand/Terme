using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Terme.Core.Domain.Masters.Dtos;
using Terme.Core.Domain.Masters.Queries;
using Terme.Framework.Commands;
using Terme.Framework.Queries;
using Terme.Framework.Resources;
using Terme.Framework.Web;

namespace Terme.Endpoints.WebUI.Controllers
{
    public class MasterController : BaseController
    {
        public MasterController(CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher, IResourceManager resourceManager) : base(commandDispatcher, queryDispatcher, resourceManager)
        {
        }

        public IActionResult List()
        {
            var masterCollection = _queryDispatcher.Dispatch<List<DtoMasterBrief>>(new AllMasterQuery());
            return View(masterCollection);
        }
        public IActionResult get(long Id)
        {
            var master = _queryDispatcher.Dispatch<DtoMasterDetails>(new MasterDetailsQuery {MasterId=Id });
            return View(master);
        }

    }
}