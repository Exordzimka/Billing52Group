using System.Collections.Generic;

namespace Billing52Group.Models
{
    public class ContractGroup
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        public virtual ICollection<Contract> Contract { get; set; } = new HashSet<Contract>();
    }
}
