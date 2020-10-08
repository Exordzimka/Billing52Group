using System.Collections.Generic;

namespace Billing52Group.Models.Api.V1
{
    public class ServiceViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        public double Cost { get; set; }

        public int Moduleid { get; set; }

        public virtual ModuleViewModel Module { get; set; }

        public virtual ICollection<ContractServiceViewModel> Contractservice { get; set; } = new List<ContractServiceViewModel>();
    }
}
