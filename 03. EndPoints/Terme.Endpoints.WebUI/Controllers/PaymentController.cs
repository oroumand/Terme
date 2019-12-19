using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Terme.Core.Domain.Orders.Commands;
using Terme.Core.Domain.Orders.Entities;
using Terme.Core.Domain.Orders.Queries;
using Terme.Core.Domain.Payments;
using Terme.Framework.Commands;
using Terme.Framework.Queries;
using Terme.Framework.Resources;
using Terme.Framework.Web;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Terme.Endpoints.WebUI.Controllers
{
    public class PaymentController : BaseController
    {

        private readonly PaymentService payment;
        private readonly IConfiguration configuration;



        public PaymentController(PaymentService payment, IConfiguration configuration,CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher, IResourceManager resourceManager) : base(commandDispatcher, queryDispatcher, resourceManager)
        {
            this.payment = payment;
            this.configuration = configuration;
        }

        // GET: /<controller>/
        [HttpPost]
        public IActionResult RequestPayment(int orderId)
        {
            var order = _queryDispatcher.Dispatch<Order>(new OrderByIdQuery
            {
                OrderId = orderId
            });
            var result = payment.RequestPayment(order.OrderLines.Sum(c => c.Price).ToString(), "09122345677", order.Id.ToString(), $"Description {order.Customer.FirstName} {order.Customer.LastName}");
            if (result.IsCorrect)
            {
                _commandDispatcher.Dispatch(new SetTransactionCommand
                {
                    OrderId = orderId,
                    paymentId = result.Token
                });               
                return Redirect($"{configuration["PayIr:PaymentUrl"]}{result.Token}");
            }
            return View("PaymentError", result);
        }

        public IActionResult Verify(PaymentResult result)
        {
            if (result.IsCorrect)
            {
                var verifyResult = payment.VerifyPayment(result.Token.ToString());
                if (verifyResult.IsCorrect)
                {
                    _commandDispatcher.Dispatch(new SetPaymentDoneCommand
                    {
                        OrderId = long.Parse(verifyResult.factorNumber),
                    });
                    return View("PaymentCompelete", verifyResult);
                }


            }
            return View("PaymentError", result);

        }
    }
}
