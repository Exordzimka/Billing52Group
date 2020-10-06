using System;
using System.Collections.Generic;

namespace Billing52Group.Server.Models
{
    public class Contract
    {
        public Contract()
        {
            Contractaccount = new HashSet<ContractAccount>();
            Contractbalance = new HashSet<ContractBalance>();
            Contractcharge = new HashSet<ContractCharge>();
            Contractlimit = new HashSet<ContractLimit>();
            Contractmodule = new HashSet<ContractModule>();
            Contractparams = new HashSet<ContractParams>();
            Contractpayment = new HashSet<ContractPayment>();
            Contractservice = new HashSet<ContractService>();
            Contractstatus = new HashSet<ContractStatus>();
            Contracttariff = new HashSet<ContractTariff>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Date1 { get; set; }

        public DateTime? Date2 { get; set; }

        public sbyte Fc { get; set; }

        public string Comment { get; set; }

        public int? Contractgroupid { get; set; }

        public virtual ContractGroup ContractGroup { get; set; }

        public virtual ICollection<ContractAccount> Contractaccount { get; set; }

        public virtual ICollection<ContractBalance> Contractbalance { get; set; }

        public virtual ICollection<ContractCharge> Contractcharge { get; set; }

        public virtual ICollection<ContractLimit> Contractlimit { get; set; }

        public virtual ICollection<ContractModule> Contractmodule { get; set; }

        public virtual ICollection<ContractParams> Contractparams { get; set; }

        public virtual ICollection<ContractPayment> Contractpayment { get; set; }

        public virtual ICollection<ContractService> Contractservice { get; set; }

        public virtual ICollection<ContractStatus> Contractstatus { get; set; }

        public virtual ICollection<ContractTariff> Contracttariff { get; set; }
    }
}
