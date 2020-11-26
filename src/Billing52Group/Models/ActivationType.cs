using System.Collections.Generic;

namespace Billing52Group.Models
{
    public class ActivationType
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public virtual ICollection<TariffPlan> TariffPlan { get; set; } = new List<TariffPlan>();
        
        public virtual ICollection<Service> Service { get; set; } = new List<Service>();
    }
}
