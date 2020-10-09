using Billing52Group.Models.Api.V1;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Billing52Group.Client.HttpServices
{
    public abstract class BillingApiHttpServiceBase
    {
        protected const uint _timeOut = 10;

        protected abstract Task<TResult> SendRequest<TResult>(HttpMethod method, string path);

        public abstract Task<IEnumerable<ContractViewModel>> GetContracts();
    }
}
