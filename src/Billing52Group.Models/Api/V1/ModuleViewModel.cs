using System.Collections.Generic;

namespace Billing52Group.Models.Api.V1
{
    public class ModuleViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<ContractModuleViewModel> ContractModule { get; set; } = new List<ContractModuleViewModel>();

        public bool ShouldSerializeContractModule() => ContractModule.Count > 0;

        public virtual ICollection<ServiceViewModel> Service { get; set; } = new List<ServiceViewModel>();

        public bool ShouldSerializeService() => Service.Count > 0;
    }
}
