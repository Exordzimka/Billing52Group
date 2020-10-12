using System;

namespace Billing52Group.Server.Models
{
    public class ContractStatus
    {
        public int Id { get; set; }

        public int ContractId { get; set; }

        public int StatusId { get; set; }

        public DateTime Startdate { get; set; }

        public virtual Contract Contract { get; set; }

        public virtual Status Status { get; set; }
    }
}
