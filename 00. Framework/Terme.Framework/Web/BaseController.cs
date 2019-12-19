using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Terme.Framework.Commands;
using Terme.Framework.Queries;
using Terme.Framework.Resources;

namespace Terme.Framework.Web
{
    public class BaseController : Controller
    {
        protected readonly CommandDispatcher _commandDispatcher;
        protected readonly QueryDispatcher _queryDispatcher;
        protected readonly IResourceManager _resourceManager;

        public BaseController(CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher,  IResourceManager resourceManager)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            _resourceManager = resourceManager;
        }
    }
}
