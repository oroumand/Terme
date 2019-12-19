using System;
using System.Collections.Generic;
using System.Text;

namespace Terme.Core.Domain.Payments
{
    public interface PaymentService
    {
        RequestPaymentResult RequestPayment(string amount, string mobile, string factorNumber, string description);
        VerifyPayemtnResult VerifyPayment(string token);
    }
}
