using System.Collections.Generic;

namespace Billing52Group.Models
{
    public class TariffPlan
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int TariffGroupId { get; set; }

        public double Cost { get; set; }

        public virtual TariffGroup TariffGroup { get; set; }

        public int? ActivationTypeId { get; set; }
        
        public virtual ActivationType ActivationType { get; set; }

        public virtual ICollection<ContractTariff> ContractTariff { get; set; } = new HashSet<ContractTariff>();
    }
}
