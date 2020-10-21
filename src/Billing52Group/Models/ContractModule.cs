namespace Billing52Group.Models
{
    public class ContractModule
    {
        public int ContractId { get; set; }

        public int Moduleid { get; set; }

        public virtual Contract Contract { get; set; }

        public virtual Module Module { get; set; }
    }
}
