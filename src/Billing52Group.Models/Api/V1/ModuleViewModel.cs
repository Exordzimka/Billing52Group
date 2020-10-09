using System.Collections.Generic;

namespace Billing52Group.Models.Api.V1
{
    public class ModuleViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<ContractModuleViewModel> Contractmodule { get; set; } = new List<ContractModuleViewModel>();

        public virtual ICollection<ServiceViewModel> Service { get; set; } = new List<ServiceViewModel>();
    }
}
