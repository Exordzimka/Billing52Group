using System.Collections.Generic;

namespace Billing52Group.Server.Models
{
    public class TariffGroup
    {
        public TariffGroup() => Tariffplan = new HashSet<TariffPlan>();

        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<TariffPlan> Tariffplan { get; set; }
    }
}
