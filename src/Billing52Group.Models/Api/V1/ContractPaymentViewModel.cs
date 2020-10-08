namespace Billing52Group.Models.Api.V1
{
    public class ContractPaymentViewModel
    {
        public int Id { get; set; }

        public double Summa { get; set; }

        public string Comment { get; set; }

        public int Paymentid { get; set; }

        public int Contractid { get; set; }

        public virtual ContractViewModel Contract { get; set; }

        public virtual PaymentViewModel Payment { get; set; }
    }
}
