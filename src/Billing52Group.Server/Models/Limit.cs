using System.Collections.Generic;

namespace Billing52Group.Server.Models
{
    public class Limit
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Limit1 { get; set; }

        public virtual ICollection<ContractLimit> ContractLimit { get; set; } = new List<ContractLimit>();
    }
}
