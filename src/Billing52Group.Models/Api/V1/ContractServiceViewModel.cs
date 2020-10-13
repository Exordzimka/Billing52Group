using System;
using Newtonsoft.Json;

namespace Billing52Group.Models.Api.V1
{
    public class ContractServiceViewModel
    {
        public int Id { get; set; }

        public DateTime Date1 { get; set; }

        public DateTime? Date2 { get; set; }

        public string Comment { get; set; }

        public int ContractId { get; set; }

        public int ServiceId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual ContractViewModel Contract { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual ServiceViewModel Service { get; set; }
    }
}
