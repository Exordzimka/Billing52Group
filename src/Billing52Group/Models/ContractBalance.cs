namespace Billing52Group.Models
{
    public class ContractBalance
    {
        public int Yy { get; set; }

        public int Mm { get; set; }

        public double Summa { get; set; }

        public int ContractId { get; set; }

        public virtual Contract Contract { get; set; }
    }
}
