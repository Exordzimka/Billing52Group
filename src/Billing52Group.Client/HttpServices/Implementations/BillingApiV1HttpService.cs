using Billing52Group.Client.Exceptions;
using Billing52Group.Models.Api.V1;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Billing52Group.Client.HttpServices.Implementations
{
    public sealed class BillingApiV1HttpService : BillingApiHttpServiceBase
    {
        const string _developBaseAddress = "https://billing52group.azurewebsites.net/api/v1/";

        public override Task<IEnumerable<ContractViewModel>> GetContracts()
        {
            return SendRequest<IEnumerable<ContractViewModel>>(HttpMethod.Get, "contracts");
        }

        /// <summary>
        /// Сделать запрос на бэк
        /// </summary>
        /// <typeparam name="TResult">Предполагаемый результат с бэка</typeparam>
        /// <param name="method">Http-метод запроса</param>
        /// <param name="path">Путь без префикса в виде версии API</param>
        protected override async Task<TResult> SendRequest<TResult>(HttpMethod method, string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("Invalid path");

            using var client = new HttpClient
            {
                BaseAddress = new Uri(_developBaseAddress),
                Timeout = TimeSpan.FromSeconds(_timeOut),
            };

            using var response = await client.SendAsync(new HttpRequestMessage(method, path));
            var body = await response.Content.ReadAsStringAsync();

            var serializerOptions = new JsonSerializerOptions
                { IgnoreNullValues = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            if (response.IsSuccessStatusCode)
                return JsonSerializer.Deserialize<TResult>(body, serializerOptions);

            if (string.IsNullOrEmpty(body))
                throw new BadRequestException(response.StatusCode);
            throw new BadRequestException(response.StatusCode, body);
        }
    }
}
