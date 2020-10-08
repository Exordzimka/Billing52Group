using System;
using System.Collections.Generic;

namespace Billing52Group.Models.Api.V1
{
    public class PaymentViewModel
    {
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        public string Title { get; set; }

        public virtual ICollection<ContractPaymentViewModel> Contractpayment { get; set; } = new List<ContractPaymentViewModel>();
    }
}
