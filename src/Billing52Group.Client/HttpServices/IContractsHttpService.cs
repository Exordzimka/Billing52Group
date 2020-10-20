using Billing52Group.Models.Api.V1;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing52Group.Client.HttpServices
{
    public interface IContractsHttpService
    {
        /// <summary>
        /// Получить все контракты, без вложенных моделей
        /// </summary>
        /// <returns>Все контракты</returns>
        Task<IEnumerable<ContractViewModel>> GetAll();

        /// <summary>
        /// Получить контракт по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeOtherModels">Если true, то в результат будут вложены связанные модели</param>
        /// <returns>Контракт с запрашиваемым id</returns>
        Task<ContractViewModel> Get(int id, bool includeOtherModels = false);

        /// <summary>
        /// Создать контракт
        /// </summary>
        /// <param name="instance"></param>
        /// <returns>Uri к новому контракту</returns>
        Task<string> Create(CreateContractArguments instance);

        /// <summary>
        /// Обновить контракт
        /// </summary>
        /// <param name="instance">Обновленный контракт</param>
        /// <returns>Обновленный контракт</returns>
        Task<ContractViewModel> Update(UpdateContractArguments instance);

        /// <summary>
        /// Удалить контракт по id
        /// </summary>
        /// <param name="id">id контракта</param>
        /// <returns>id удаленного контракта</returns>
        Task<int> Delete(int id);
    }
}
