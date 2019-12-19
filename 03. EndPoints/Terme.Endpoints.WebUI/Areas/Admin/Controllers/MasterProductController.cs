using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Terme.Core.Domain.Categories.Entities;
using Terme.Core.Domain.Categories.Queries;
using Terme.Core.Domain.Masters.Commands;
using Terme.Core.Domain.Masters.Dtos;
using Terme.Core.Domain.Masters.Entities;
using Terme.Core.Domain.Masters.Enums;
using Terme.Core.Domain.Masters.Queries;
using Terme.Core.Domain.Photos.Dtos;
using Terme.Endpoints.WebUI.Areas.Admin.Models.Masters;
using Terme.Endpoints.WebUI.FileServices;
using Terme.Framework.Commands;
using Terme.Framework.Queries;
using Terme.Framework.Resources;
using Terme.Framework.Web;

namespace Terme.Endpoints.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MasterProductController : BaseController
    {


        public MasterProductController(CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher, IResourceManager resourceManager) : base(commandDispatcher, queryDispatcher, resourceManager)
        {
        }


        public IActionResult Index(int CurrentPage = 1, string q = "", long MasterId = -1, long CategoryId = -1, int OrderBy = (int)EnumOrderByProduct.NewestToOldest)
        {
            DtoPassRequestToViewComponentProduct dtoRequest = new DtoPassRequestToViewComponentProduct { CurrentPage = CurrentPage, TextSeach = q, MasterId = MasterId, CategoryId = CategoryId, OrderByProduct = (EnumOrderByProduct)OrderBy };
            return View(dtoRequest);
        }

        public IActionResult AddMasterProduct()
        {
            var model = new AddMasterProductViewModel
            {
                Categories = _queryDispatcher.Dispatch<List<Category>>(new ParentCategoryQuery()),
                Masters = _queryDispatcher.Dispatch<List<DtoMasterBrief>>(new AllMasterQuery())
            };
            return View(model);
        }


        [HttpPost]
        public IActionResult AddMasterProduct(AddMasterProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                string MainPhotofileUrl=new FileSaver().Save(model.MainPhoto);


                var dtoPhotoUrlSizes = new List<DtoPhotoUrlSize>();
                foreach (var photo in model.Photos)
                {
                    var fileUrl = new FileSaver().Save(photo);
                    dtoPhotoUrlSizes.Add(new DtoPhotoUrlSize(fileUrl, 0));
                }
                //
                var result = _commandDispatcher.Dispatch(new AddMasterProductCommand
                {
                    Name = model.Name,
                    Price = model.Price,
                    Discount = model.Discount,
                    Description = model.Description,
                    ShortDescription = model.ShortDescription,
                    CategoryId = model.CategoryId,
                    MasterId = model.MasterId,
                    DtoPhotoUrlSizes = dtoPhotoUrlSizes,
                    MainPhotoUrlSize=new DtoPhotoUrlSize( MainPhotofileUrl,0 )
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


