using System;

namespace Billing52Group.Models.Api.V1
{
    public class ContractStatusViewModel
    {
        public int Id { get; set; }

        public int Contractid { get; set; }

        public int Statusid { get; set; }

        public DateTime Startdate { get; set; }

        public virtual ContractViewModel Contract { get; set; }

        public virtual ContractStatusViewModel Status { get; set; }
    }
}
