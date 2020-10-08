using System;
using System.Collections.Generic;

namespace Billing52Group.Server.Models
{
    public class Contract
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Date1 { get; set; }

        public DateTime? Date2 { get; set; }

        public sbyte Fc { get; set; }

        public string Comment { get; set; }

        public int? Contractgroupid { get; set; }

        public virtual ContractGroup ContractGroup { get; set; }

        public virtual ICollection<ContractAccount> ContractAccounts { get; set; } = new List<ContractAccount>();

        public virtual ICollection<ContractBalance> ContractBalance { get; set; } = new List<ContractBalance>();

        public virtual ICollection<ContractCharge> ContractCharge { get; set; } = new List<ContractCharge>();

        public virtual ICollection<ContractLimit> ContractLimit { get; set; } = new List<ContractLimit>();

        public virtual ICollection<ContractModule> ContractModule { get; set; } = new List<ContractModule>();

        public virtual ICollection<ContractParams> ContractParams { get; set; } = new List<ContractParams>();

        public virtual ICollection<ContractPayment> ContractPayment { get; set; } = new List<ContractPayment>();

        public virtual ICollection<ContractService> ContractService { get; set; } = new List<ContractService>();

        public virtual ICollection<ContractStatus> ContractStatus { get; set; } = new List<ContractStatus>();

        public virtual ICollection<ContractTariff> ContractTariff { get; set; } = new List<ContractTariff>();
    }
}
