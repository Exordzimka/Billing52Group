using System.Collections.Generic;

namespace Billing52Group.Server.Models
{
    public class TariffPlan
    {
        public TariffPlan() => Contracttariff = new HashSet<ContractTariff>();

        public int Id { get; set; }

        public string Title { get; set; }

        public int? Tariffgroupid { get; set; }

        public double? Cost { get; set; }

        public virtual TariffGroup TariffGroup { get; set; }

        public virtual ICollection<ContractTariff> Contracttariff { get; set; }
    }
}
