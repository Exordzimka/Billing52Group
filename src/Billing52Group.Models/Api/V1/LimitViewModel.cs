using System.Collections.Generic;

namespace Billing52Group.Models.Api.V1
{
    public class LimitViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Limit1 { get; set; }

        public virtual ICollection<ContractLimitViewModel> ContractLimit { get; set; } = new List<ContractLimitViewModel>();

        public bool ShouldSerializeContractLimit() => ContractLimit.Count > 0;
    }
}
