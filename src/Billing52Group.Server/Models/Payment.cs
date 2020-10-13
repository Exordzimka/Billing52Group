using System;
using System.Collections.Generic;

namespace Billing52Group.Server.Models
{
    public class Payment
    {
        public Payment() => ContractPayment = new HashSet<ContractPayment>();

        public int Id { get; set; }

        public DateTime? Date { get; set; }

        public string Title { get; set; }

        public virtual ICollection<ContractPayment> ContractPayment { get; set; }
    }
}
