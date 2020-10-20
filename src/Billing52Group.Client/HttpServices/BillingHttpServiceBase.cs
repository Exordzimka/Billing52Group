using Billing52Group.Client.Constants;
using Billing52Group.Client.Exceptions;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Billing52Group.Client.HttpServices
{
    public abstract class BillingHttpServiceBase
    {
        const uint _timeOut = 10;

        const string _baseUrl = "https://billing52group.azurewebsites.net/api/";

        /// <summary>
        /// Сделать запрос на бэк
        /// </summary>
        /// <typeparam name="TResult">Предполагаемый результат с бэка</typeparam>
        /// <param name="method">Http-метод запроса</param>
        /// <param name="path">Путь без префикса в виде версии API</param>
        /// <param name="content">Тело запроса</param>
        protected virtual async Task<TResult> SendRequest<TResult>(HttpMethod method, string path, object content = null)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("Invalid path");

            using var client = new HttpClient
            {
                BaseAddress = new Uri(_baseUrl),
                Timeout = TimeSpan.FromSeconds(_timeOut),
            };

            var request = new HttpRequestMessage(method, path);
            if (content != default)
                request.Content =
                    new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, MimeTypes.Application.Json);

            using var response = await client.SendAsync(request);
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
