using System;
using System.Collections.Generic;

namespace Billing52Group.Models
{
    public class PaymentType
    {
        public PaymentType() => ContractPayment = new HashSet<ContractPayment>();

        public int Id { get; set; }

        public string Title { get; set; }
        
        public virtual ICollection<ContractPayment> ContractPayment { get; set; }
    }
}
