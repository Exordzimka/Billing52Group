using System;

namespace Billing52Group.Server.Models
{
    public class ContractLimit
    {
        public int Id { get; set; }

        public int Contractid { get; set; }

        public int Limitid { get; set; }

        public DateTime Startdate { get; set; }

        public virtual Contract Contract { get; set; }

        public virtual Limit Limit { get; set; }
    }
}
