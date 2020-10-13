using Newtonsoft.Json;

namespace Billing52Group.Models.Api.V1
{
    public class ContractPaymentViewModel
    {
        public int Id { get; set; }

        public double Summa { get; set; }

        public string Comment { get; set; }

        public int PaymentId { get; set; }

        public int ContractId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual ContractViewModel Contract { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual PaymentViewModel Payment { get; set; }
    }
}
