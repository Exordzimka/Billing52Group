using System.Collections.Generic;

namespace Billing52Group.Server.Models
{
    public class Parameters
    {
        public Parameters() => Contractparams = new HashSet<ContractParams>();

        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<ContractParams> Contractparams { get; set; }
    }
}
