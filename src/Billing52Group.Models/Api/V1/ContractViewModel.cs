using Newtonsoft.Json;
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

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual ContractGroupViewModel ContractGroup { get; set; }

        public virtual ICollection<ContractAccountViewModel> ContractAccounts { get; set; } = new List<ContractAccountViewModel>();

        public bool ShouldSerializeContractAccounts() => ContractAccounts.Count > 0;

        public virtual ICollection<ContractBalanceViewModel> ContractBalance { get; set; } = new List<ContractBalanceViewModel>();

        public bool ShouldSerializeContractBalance() => ContractBalance.Count > 0;

        public virtual ICollection<ContractChargeViewModel> ContractCharge { get; set; } = new List<ContractChargeViewModel>();

        public bool ShouldSerializeContractCharge() => ContractCharge.Count > 0;

        public virtual ICollection<ContractLimitViewModel> ContractLimit { get; set; } = new List<ContractLimitViewModel>();

        public bool ShouldSerializeContractLimit() => ContractLimit.Count > 0;

        public virtual ICollection<ContractModuleViewModel> ContractModule { get; set; } = new List<ContractModuleViewModel>();

        public bool ShouldSerializeContractModule() => ContractModule.Count > 0;

        public virtual ICollection<ContractParamsViewModel> ContractParams { get; set; } = new List<ContractParamsViewModel>();

        public bool ShouldSerializeContractParams() => ContractParams.Count > 0;

        public virtual ICollection<ContractPaymentViewModel> ContractPayment { get; set; } = new List<ContractPaymentViewModel>();

        public bool ShouldSerializeContractPayment() => ContractPayment.Count > 0;

        public virtual ICollection<ContractServiceViewModel> ContractService { get; set; } = new List<ContractServiceViewModel>();

        public bool ShouldSerializeContractService() => ContractService.Count > 0;

        public virtual ICollection<ContractStatusViewModel> ContractStatus { get; set; } = new List<ContractStatusViewModel>();

        public bool ShouldSerializeContractStatus() => ContractStatus.Count > 0;

        public virtual ICollection<ContractTariffViewModel> ContractTariff { get; set; } = new List<ContractTariffViewModel>();

        public bool ShouldSerializeContractTariff() => ContractTariff.Count > 0;
    }
}
