using System.Collections.Generic;

namespace Billing52Group.Server.Models
{
    public class Module
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<ContractModule> ContractModule { get; set; } = new HashSet<ContractModule>();

        public virtual ICollection<Service> Service { get; set; } = new HashSet<Service>();
    }
}
