namespace Billing52Group.Server.Models
{
    public class ContractPayment
    {
        public int Id { get; set; }

        public double Summa { get; set; }

        public string Comment { get; set; }

        public int Paymentid { get; set; }

        public int Contractid { get; set; }

        public virtual Contract Contract { get; set; }

        public virtual Payment Payment { get; set; }
    }
}
