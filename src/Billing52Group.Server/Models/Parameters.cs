using System.Collections.Generic;

namespace Billing52Group.Server.Models
{
    public class Parameters
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<ContractParams> ContractParams { get; set; } = new HashSet<ContractParams>();
    }
}
