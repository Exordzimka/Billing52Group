namespace Billing52Group.Models.Api.V1
{
    public class ContractModuleViewModel
    {
        public int ContractId { get; set; }

        public int ModuleId { get; set; }

        public virtual ContractViewModel Contract { get; set; }

        public virtual ModuleViewModel Module { get; set; }
    }
}
