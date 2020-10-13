using System;

namespace Billing52Group.Server.Models
{
    public class ContractService
    {
        public int Id { get; set; }

        public DateTime Date1 { get; set; }

        public DateTime? Date2 { get; set; }

        public string Comment { get; set; }

        public int ContractId { get; set; }

        public int ServiceId { get; set; }

        public virtual Contract Contract { get; set; }

        public virtual Service Service { get; set; }
    }
}
