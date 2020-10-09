using System.Collections.Generic;

namespace Billing52Group.Models.Api.V1
{
    public class TariffPlanViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int? TariffGroupId { get; set; }

        public double? Cost { get; set; }

        public virtual TariffGroupViewModel TariffGroup { get; set; }

        public virtual ICollection<ContractTariffViewModel> ContractTariff { get; set; } = new List<ContractTariffViewModel>();
    }
}
