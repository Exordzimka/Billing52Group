using System.Collections.Generic;

namespace Billing52Group.Server.Models
{
    public class ContractGroup
    {
        public ContractGroup() => Contract = new HashSet<Contract>();

        public int Id { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        public virtual ICollection<Contract> Contract { get; set; }
    }
}
