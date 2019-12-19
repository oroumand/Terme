namespace Terme.Core.Domain.Payments
{
    public abstract class BankRequestResult
    {
        public int Status { get; set; }
        public string Token { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public bool IsCorrect => Status == 1;
    }
}
