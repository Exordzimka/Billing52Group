namespace Billing52Group.Models.Api.V1
{
    public class ContractAccountViewModel
    {
        public int Yy { get; set; }

        public bool Mm { get; set; }

        public int Contractid { get; set; }

        public double Summa { get; set; }

        public virtual ContractViewModel Contract { get; set; }
    }
}
