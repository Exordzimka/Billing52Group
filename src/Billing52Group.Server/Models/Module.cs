using System.Collections.Generic;

namespace Billing52Group.Server.Models
{
    public class Module
    {
        public Module()
        {
            Contractmodule = new HashSet<ContractModule>();
            Service = new HashSet<Service>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<ContractModule> Contractmodule { get; set; }

        public virtual ICollection<Service> Service { get; set; }
    }
}
