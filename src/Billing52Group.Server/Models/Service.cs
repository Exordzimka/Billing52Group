using System.Collections.Generic;

namespace Billing52Group.Server.Models
{
    public class Service
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        public double Cost { get; set; }

        public int Moduleid { get; set; }

        public virtual Module Module { get; set; }

        public virtual ICollection<ContractService> ContractService { get; set; } = new HashSet<ContractService>();
    }
}
