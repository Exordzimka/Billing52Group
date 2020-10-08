using System;

namespace Billing52Group.Models.Api.V1
{
    public class ContractServiceViewModel
    {
        public int Id { get; set; }

        public DateTime Date1 { get; set; }

        public DateTime? Date2 { get; set; }

        public string Comment { get; set; }

        public int Contractid { get; set; }

        public int Serviceid { get; set; }

        public virtual ContractViewModel Contract { get; set; }

        public virtual ServiceViewModel Service { get; set; }
    }
}
