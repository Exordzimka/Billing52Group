using System.Collections.Generic;

namespace Billing52Group.Server.Models
{
    public class Limit
    {
        public Limit() => Contractlimit = new HashSet<ContractLimit>();

        public int Id { get; set; }

        public string Title { get; set; }

        public string Limit1 { get; set; }

        public virtual ICollection<ContractLimit> Contractlimit { get; set; }
    }
}
