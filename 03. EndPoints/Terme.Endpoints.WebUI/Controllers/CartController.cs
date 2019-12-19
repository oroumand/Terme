using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Terme.Core.Domain.Carts;
using Terme.Core.Domain.Masters.Entities;
using Terme.Core.Domain.Masters.Queries;
using Terme.Endpoints.WebUI.Models.Carts;
using Terme.Framework.Commands;
using Terme.Framework.Queries;
using Terme.Framework.Resources;
using Terme.Framework.Web;

namespace Terme.Endpoints.WebUI.Controllers
{
    public class CartController : BaseController
    {

        private Cart _cart;

        public CartController(CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher,
            IResourceManager resourceManager, Cart cart) :
            base(commandDispatcher, queryDispatcher, resourceManager)
        {
            _cart = cart;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = _cart,
                ReturnUrl = returnUrl
            });

        }
        [HttpPost]
        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            var product = _queryDispatcher.Dispatch<MasterProduct>(new ProductByIdQuery { ProductId = productId });
            if (product != null)
            {
                _cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            var product = _queryDispatcher.Dispatch<MasterProduct>(new ProductByIdQuery { ProductId = productId });
            if (product != null)
            {
                _cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
