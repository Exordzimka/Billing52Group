using System;

namespace Billing52Group.Server.Models
{
    public class ContractTariff
    {
        public int Id { get; set; }

        public DateTime Date1 { get; set; }

        public DateTime? Date2 { get; set; }

        public string Comment { get; set; }

        public int Contractid { get; set; }

        public int Tariffplanid { get; set; }

        public virtual Contract Contract { get; set; }

        public virtual TariffPlan TariffPlan { get; set; }
    }
}
