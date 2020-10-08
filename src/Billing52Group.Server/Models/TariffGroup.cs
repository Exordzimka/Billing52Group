using System.Collections.Generic;

namespace Billing52Group.Server.Models
{
    public class TariffGroup
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<TariffPlan> Tariffplan { get; set; } = new List<TariffPlan>();
    }
}
