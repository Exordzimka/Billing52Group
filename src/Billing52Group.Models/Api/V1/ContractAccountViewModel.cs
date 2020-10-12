using Newtonsoft.Json;

namespace Billing52Group.Models.Api.V1
{
    public class ContractAccountViewModel
    {
        public int Yy { get; set; }

        public bool Mm { get; set; }

        public int ContractId { get; set; }

        public double Summa { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual ContractViewModel Contract { get; set; }
    }
}
