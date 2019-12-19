using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Terme.Core.Domain.Masters.Dtos;
using Terme.Core.Domain.Masters.Queries;
using Terme.Endpoints.WebUI.Models;
using Terme.Framework.Commands;
using Terme.Framework.Queries;
using Terme.Framework.Resources;
using Terme.Framework.Web;

namespace Terme.Endpoints.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher, IResourceManager resourceManager, ILogger<HomeController> logger) : base(commandDispatcher, queryDispatcher, resourceManager)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
