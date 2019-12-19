namespace Terme.Core.Domain.Payments
{
    public class VerifyPayemtnResult
    {
        public int Status { get; set; }
        public string amount { get; set; }
        public string transId { get; set; }
        public string factorNumber { get; set; }
        public string mobile { get; set; }
        public string description { get; set; }
        public string cardNumber { get; set; }
        public string message { get; set; }
        public string errorCode { get; set; }
        public string errorMessage { get; set; }
        public bool IsCorrect => Status == 1;


    }
}
