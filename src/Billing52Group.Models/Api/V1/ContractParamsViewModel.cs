namespace Billing52Group.Models.Api.V1
{
    public class ContractParamsViewModel
    {
        public int Id { get; set; }

        public int ContractId { get; set; }

        public int ParamId { get; set; }

        public string Value { get; set; }

        public virtual ContractViewModel Contract { get; set; }

        public virtual ParametersViewModel Param { get; set; }
    }
}
