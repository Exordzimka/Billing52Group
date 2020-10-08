using System.Collections.Generic;

namespace Billing52Group.Models.Api.V1
{
    public class TariffPlanViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int? Tariffgroupid { get; set; }

        public double? Cost { get; set; }

        public virtual TariffGroupViewModel TariffGroup { get; set; }

        public virtual ICollection<ContractTariffViewModel> Contracttariff { get; set; } = new List<ContractTariffViewModel>();
    }
}
