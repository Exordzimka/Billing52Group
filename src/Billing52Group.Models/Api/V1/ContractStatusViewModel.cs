using System;
using Newtonsoft.Json;

namespace Billing52Group.Models.Api.V1
{
    public class ContractStatusViewModel
    {
        public int Id { get; set; }

        public int ContractId { get; set; }

        public int StatusId { get; set; }

        public DateTime StartDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual ContractViewModel Contract { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual ContractStatusViewModel Status { get; set; }
    }
}
