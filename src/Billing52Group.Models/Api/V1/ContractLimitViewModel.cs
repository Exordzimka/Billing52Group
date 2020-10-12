using System;
using Newtonsoft.Json;

namespace Billing52Group.Models.Api.V1
{
    public class ContractLimitViewModel
    {
        public int Id { get; set; }

        public int ContractId { get; set; }

        public int LimitId { get; set; }

        public DateTime StartDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual ContractViewModel Contract { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual LimitViewModel Limit { get; set; }
    }
}
