using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Terme.Core.Domain.Masters.Dtos;
using Terme.Core.Domain.Masters.Entities;
using Terme.Core.Domain.Masters.Enums;
using Terme.Core.Domain.Masters.Queries;
using Terme.Framework.Commands;
using Terme.Framework.Queries;
using Terme.Framework.Resources;
using Terme.Framework.Web;

namespace Terme.Endpoints.WebUI.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher, IResourceManager resourceManager) : base(commandDispatcher, queryDispatcher, resourceManager)
        {
        }

        public IActionResult List(int CurrentPage = 1, string q = "", long MasterId = -1, long CategoryId = -1, int OrderBy = (int)EnumOrderByProduct.NewestToOldest)
        {
            DtoPassRequestToViewComponentProduct dtoRequest = new DtoPassRequestToViewComponentProduct { CurrentPage = CurrentPage, TextSeach = q, MasterId = MasterId, CategoryId = CategoryId, OrderByProduct = (EnumOrderByProduct)OrderBy };
            return View(dtoRequest);
        }

        public IActionResult get(long Id)
        {
            var productCollection = _queryDispatcher.Dispatch<DtoProductDetails>(new ProductDetailsQuery { ProductId = Id });
            return View(productCollection);
        }
    }
}