using System;

namespace Billing52Group.Models.Api.V1
{
    public class ContractLimitViewModel
    {
        public int Id { get; set; }

        public int ContractId { get; set; }

        public int LimitId { get; set; }

        public DateTime StartDate { get; set; }

        public virtual ContractViewModel Contract { get; set; }

        public virtual LimitViewModel Limit { get; set; }
    }
}
