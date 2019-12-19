using Microsoft.AspNetCore.Mvc;
using Terme.Core.Domain.Carts;

namespace Terme.Endpoints.WebUI.Controllers.Shared
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;
        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }



}
