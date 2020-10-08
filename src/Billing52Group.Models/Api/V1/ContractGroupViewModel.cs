using System.Collections.Generic;

namespace Billing52Group.Models.Api.V1
{
    public class ContractGroupViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        public virtual ICollection<ContractViewModel> Contracts { get; set; } = new List<ContractViewModel>();
    }
}
