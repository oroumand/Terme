using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Terme.Core.Domain.Categories.Commands;
using Terme.Core.Domain.Categories.Entities;
using Terme.Core.Domain.Categories.Queries;
using Terme.Endpoints.WebUI.Areas.Admin.Models.Categories;
using Terme.Endpoints.WebUI.FileServices;
using Terme.Framework.Commands;
using Terme.Framework.Queries;
using Terme.Framework.Resources;
using Terme.Framework.Web;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Terme.Endpoints.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : BaseController
    {
        public CategoriesController(CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher, IResourceManager resourceManager) : base(commandDispatcher, queryDispatcher, resourceManager)
        {
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var allCategory = _queryDispatcher.Dispatch<List<Category>>(new AllCategoryQuery());
            return View(allCategory);
        }

        public IActionResult AddCategory()
        {
            var model = new AddCategoryViewModel
            {
                Categories = _queryDispatcher.Dispatch<List<Category>>(new ParentCategoryQuery())
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddCategory(AddCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {

                var fileUrl = new FileSaver().Save(model.Photo);
                var result = _commandDispatcher.Dispatch(new AddCategoryCommand
                {
                    Name = model.Name,
                    ParentId = model.ParentId,
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
