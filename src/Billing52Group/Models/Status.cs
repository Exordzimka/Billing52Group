using System.Collections.Generic;

namespace Billing52Group.Models
{
    public class Status
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        public virtual ICollection<ContractStatus> ContractStatus { get; set; } = new HashSet<ContractStatus>();
    }
}
