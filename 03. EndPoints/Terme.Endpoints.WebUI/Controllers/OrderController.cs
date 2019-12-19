using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Terme.Core.Domain.Carts;
using Terme.Core.Domain.Orders.Commands;
using Terme.Core.Domain.Orders.Entities;
using Terme.Core.Domain.Orders.Queries;
using Terme.Endpoints.WebUI.Models.Orders;
using Terme.Framework.Commands;
using Terme.Framework.Queries;
using Terme.Framework.Resources;
using Terme.Framework.Web;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Terme.Endpoints.WebUI.Controllers
{
    public class OrderController : BaseController
    {
        private Cart cart;
        public OrderController(CommandDispatcher commandDispatcher,
                               QueryDispatcher queryDispatcher,
                               IResourceManager resourceManager,
                               Cart cartService) : base(commandDispatcher, queryDispatcher, resourceManager)
        {
            cart = cartService;
        }

        public ViewResult Checkout()
        {
            return View(new CheckoutViewModel());
        }

        [HttpPost]
        public IActionResult Checkout(CheckoutViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new CheckOutCommand
                {
                    Address = model.Address,
                    Cart = cart,
                    City = model.City,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    NationalCode = model.NationalCode,
                    Phone = model.Phone,
                    Provience = model.Provience
                };
                var result = _commandDispatcher.Dispatch(command);
                if (result.IsSuccess)
                {
                    cart.Clear();
                    return RedirectToAction(nameof(Completed), new { Id = command.OrderId });
                }
                foreach (string item in result.Errors)
                {
                    ModelState.AddModelError("", item);
                }
            }

            return View(model);
        }
        public IActionResult Completed(long id)
        {
            var order = _queryDispatcher.Dispatch<Order>(new OrderByIdQuery
            {
                OrderId = id
            });
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
    }
}
