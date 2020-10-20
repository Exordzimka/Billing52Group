using Billing52Group.Models.Api.V1;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Billing52Group.Client.HttpServices.Implementations
{
    public sealed class ContractsHttpService : BillingHttpServiceBase, IContractsHttpService
    {
        /// <inheritdoc cref="IContractsHttpService.GetAll"/>
        public Task<IEnumerable<ContractViewModel>> GetAll() =>
            SendRequest<IEnumerable<ContractViewModel>>(HttpMethod.Get, "v1/contracts");

        /// <inheritdoc cref="IContractsHttpService.Get"/>
        public Task<ContractViewModel> Get(int id, bool includeOtherModels = false) =>
            SendRequest<ContractViewModel>(HttpMethod.Get, $"v1/contracts/{id}");

        /// <inheritdoc cref="IContractsHttpService.Create"/>
        public Task<string> Create(CreateContractArguments instance) =>
            SendRequest<string>(HttpMethod.Post, "v1/contracts", instance);

        /// <inheritdoc cref="IContractsHttpService.Update"/>
        public Task<ContractViewModel> Update(UpdateContractArguments instance) =>
            SendRequest<ContractViewModel>(HttpMethod.Put, "v1/contracts", instance);

        /// <inheritdoc cref="IContractsHttpService.Delete"/>
        public Task<int> Delete(int id) =>
            SendRequest<int>(HttpMethod.Delete, $"v1/contracts/{id}");
    }
}
