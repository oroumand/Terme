using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Terme.Core.Domain.Masters.Commands;
using Terme.Core.Domain.Masters.Dtos;
using Terme.Core.Domain.Masters.Entities;
using Terme.Core.Domain.Masters.Queries;
using Terme.Endpoints.WebUI.Areas.Admin.Models.Masters;
using Terme.Endpoints.WebUI.FileServices;
using Terme.Framework.Commands;
using Terme.Framework.Queries;
using Terme.Framework.Resources;
using Terme.Framework.Web;

namespace Terme.Endpoints.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MastersController : BaseController
    {
        public MastersController(CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher, IResourceManager resourceManager) : base(commandDispatcher, queryDispatcher, resourceManager)
        {
        }

        public IActionResult Index()
        {
            var allMasters = _queryDispatcher.Dispatch<List<DtoMasterBrief>>(new AllMasterQuery());
            return View(allMasters);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var fileUrl = new FileSaver().Save(model.Photo);
                var result = _commandDispatcher.Dispatch(new AddMasterCommand
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Description = model.Description,
                    ShortDescription = model.ShortDescription,
                    PhotoUrl = fileUrl
                });
                if (result.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", result.Message);
                foreach (string item in result.Errors)
                {
                    ModelState.AddModelError("", item);
                }
            }
            return View(model);
        }
    }
}