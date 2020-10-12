using AutoMapper;
using Billing52Group.Models.Api.V1;
using Billing52Group.Server.Models;

namespace Billing52Group.Server.Configuration.MapperProfiles.Api.V1
{
    // ReSharper disable once UnusedType.Global
    public class ContractsProfile : Profile
    {
        public ContractsProfile()
        {
            CreateMap<Contract, ContractViewModel>();
            CreateMap<CreateContractArguments, Contract>();
            CreateMap<UpdateContractArguments, Contract>();
        }
    }
}
