using System;
using Newtonsoft.Json;

namespace Billing52Group.Models.Api.V1
{
    public class ContractChargeViewModel
    {
        public int Id { get; set; }

        public double Summa { get; set; }

        public string Comment { get; set; }

        public int ContractId { get; set; }

        public DateTime Date { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual ContractViewModel Contract { get; set; }
    }
}
