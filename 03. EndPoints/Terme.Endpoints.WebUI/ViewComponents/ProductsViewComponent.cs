using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Terme.Core.Domain.Masters.Dtos;
using Terme.Core.Domain.Masters.Enums;
using Terme.Core.Domain.Masters.Queries;
using Terme.Framework.Commands;
using Terme.Framework.Queries;
using Terme.Framework.Resources;

namespace Terme.Endpoints.WebUI.Controllers.Shared
{
    public class ProductsViewComponent : ViewComponent
    {

        protected readonly CommandDispatcher _commandDispatcher;
        protected readonly QueryDispatcher _queryDispatcher;
        protected readonly IResourceManager _resourceManager;

        public ProductsViewComponent(CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher, IResourceManager resourceManager)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            _resourceManager = resourceManager;
        }
        public async Task<IViewComponentResult> InvokeAsync
            (
            int numberOfProducts,
            string Title,
            EnumDisplayModeProducts displayModeProducts = EnumDisplayModeProducts.Card,
            string TextSeach = "",
            long MasterId = -1,
            long CategoryId = -1,
            EnumOrderByProduct OrderBy = EnumOrderByProduct.NewestToOldest,
            bool EnabledPaging = false,
            bool EnabledSorting=false,
            int pageNumber = 1
            )
        {
            var newProducts = await Task.Run(() => _queryDispatcher.Dispatch<DtoProductsAdvanacedQuery>(new ProductsAdvanacedQuery
            {
                number = numberOfProducts,
                TextSeach = TextSeach,
                MasterId = MasterId,
                CategoryId = CategoryId,
                OrderBy = OrderBy,
                EnabledPaging = EnabledPaging,
                EnabledSorting= EnabledSorting,
                PageNumber = pageNumber
            }));
            newProducts.Title = Title;
            newProducts.DisplayModeProducts = displayModeProducts;
            return View(newProducts.DisplayModeProducts.ToString(),newProducts);
        }
    }



}
