using System;
using System.Collections.Generic;

namespace Billing52Group.Models.Api.V1
{
    public class ContractViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Date1 { get; set; }

        public DateTime? Date2 { get; set; }

        public sbyte Fc { get; set; }

        public string Comment { get; set; }

        public int? ContractGroupId { get; set; }

        public virtual ContractGroupViewModel ContractGroup { get; set; }

        public virtual ICollection<ContractAccountViewModel> ContractAccounts { get; set; } = new List<ContractAccountViewModel>();

        public virtual ICollection<ContractBalanceViewModel> ContractBalance { get; set; } = new List<ContractBalanceViewModel>();

        public virtual ICollection<ContractChargeViewModel> ContractCharge { get; set; } = new List<ContractChargeViewModel>();

        public virtual ICollection<ContractLimitViewModel> ContractLimit { get; set; } = new List<ContractLimitViewModel>();

        public virtual ICollection<ContractModuleViewModel> ContractModule { get; set; } = new List<ContractModuleViewModel>();

        public virtual ICollection<ContractParamsViewModel> ContractParams { get; set; } = new List<ContractParamsViewModel>();

        public virtual ICollection<ContractPaymentViewModel> ContractPayment { get; set; } = new List<ContractPaymentViewModel>();

        public virtual ICollection<ContractServiceViewModel> ContractService { get; set; } = new List<ContractServiceViewModel>();

        public virtual ICollection<ContractStatusViewModel> ContractStatus { get; set; } = new List<ContractStatusViewModel>();

        public virtual ICollection<ContractTariffViewModel> ContractTariff { get; set; } = new List<ContractTariffViewModel>();
    }
}
