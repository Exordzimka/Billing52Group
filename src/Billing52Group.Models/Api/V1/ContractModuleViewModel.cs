using Newtonsoft.Json;

namespace Billing52Group.Models.Api.V1
{
    public class ContractModuleViewModel
    {
        public int ContractId { get; set; }

        public int ModuleId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual ContractViewModel Contract { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual ModuleViewModel Module { get; set; }
    }
}
