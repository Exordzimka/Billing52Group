namespace Billing52Group.Server.Models
{
    public class ContractBalance
    {
        public int Yy { get; set; }

        public bool Mm { get; set; }

        public double Summa { get; set; }

        public int ContractId { get; set; }

        public virtual Contract Contract { get; set; }
    }
}
