using System;

namespace Billing52Group.Models.Api.V1
{
    public class ContractTariffViewModel
    {
        public int Id { get; set; }

        public DateTime Date1 { get; set; }

        public DateTime? Date2 { get; set; }

        public string Comment { get; set; }

        public int Contractid { get; set; }

        public int Tariffplanid { get; set; }

        public virtual ContractViewModel Contract { get; set; }

        public virtual TariffPlanViewModel TariffPlan { get; set; }
    }
}
