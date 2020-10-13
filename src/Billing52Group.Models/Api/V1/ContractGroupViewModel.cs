using System.Collections.Generic;
using Newtonsoft.Json;

namespace Billing52Group.Models.Api.V1
{
    public class ContractGroupViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual ICollection<ContractViewModel> Contracts { get; set; }
    }
}
