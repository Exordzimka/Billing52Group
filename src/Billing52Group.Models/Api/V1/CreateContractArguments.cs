using System;

namespace Billing52Group.Models.Api.V1
{
    public class CreateContractArguments
    {
        public string Title { get; set; }

        public DateTime Date1 { get; set; }

        public DateTime? Date2 { get; set; }

        public sbyte Fc { get; set; }

        public string Comment { get; set; }

        public int? ContractGroupId { get; set; }
    }
}
