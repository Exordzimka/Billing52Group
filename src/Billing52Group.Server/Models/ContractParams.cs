namespace Billing52Group.Server.Models
{
    public class ContractParams
    {
        public int Id { get; set; }

        public int ContractId { get; set; }

        public int ParamId { get; set; }

        public string Value { get; set; }

        public virtual Contract Contract { get; set; }

        public virtual Parameters Param { get; set; }
    }
}
