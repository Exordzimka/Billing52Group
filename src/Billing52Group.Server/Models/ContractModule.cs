namespace Billing52Group.Server.Models
{
    public class ContractModule
    {
        public int Contractid { get; set; }

        public int Moduleid { get; set; }

        public virtual Contract Contract { get; set; }

        public virtual Module Module { get; set; }
    }
}
