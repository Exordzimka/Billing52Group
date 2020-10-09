using System.Collections.Generic;

namespace Billing52Group.Models.Api.V1
{
    public class ParametersViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<ContractParamsViewModel> ContractParams { get; set; } = new List<ContractParamsViewModel>();
    }
}
