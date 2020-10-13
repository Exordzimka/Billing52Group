using System.Collections.Generic;
using Newtonsoft.Json;

namespace Billing52Group.Models.Api.V1
{
    public class ServiceViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        public double Cost { get; set; }

        public int Moduleid { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual ModuleViewModel Module { get; set; }

        public virtual ICollection<ContractServiceViewModel> ContractService { get; set; } = new List<ContractServiceViewModel>();

        public bool ShouldSerializeContractService() => ContractService.Count > 0;
    }
}
