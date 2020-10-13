using AutoMapper;
using Billing52Group.Models.Api.V1;
using Billing52Group.Server.Configuration;
using Billing52Group.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing52Group.Server.Controllers.V1
{
    [Route("[area]/[controller]")]
    [ApiController]
    public sealed class ContractsController : V1ControllerBase
    {
        readonly Billing52GroupContext _context;
        readonly ILogger<ContractsController> _logger;
        readonly IMapper _mapper;

        public ContractsController(Billing52GroupContext context, ILogger<ContractsController> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }


        /// <summary>
        /// Вернуть все контракты
        /// </summary>
        /// <returns>Все контракты, зарегистрированные в системе</returns>
        [HttpGet]
        [Produces(typeof(IEnumerable<ContractViewModel>))]
        public async Task<IEnumerable<ContractViewModel>> GetAll()
        {
            var contracts = await _context.Contract.ToListAsync();
            var mapped =  _mapper.Map<IEnumerable<ContractViewModel>>(contracts);
            return mapped;
        }

        /// <summary>
        /// Получить контракт по id
        /// </summary>
        /// <param name="id">id контракта</param>
        /// <returns>Контракт с заданным id</returns>
        [HttpGet("{id}")]
        [Produces(typeof(ContractViewModel))]
        public async Task<ActionResult<ContractViewModel>> Get(int id)
        {
            var contract = await _context.Contract.FindAsync(id);
            if (contract is { }) return Ok(_mapper.Map<ContractViewModel>(contract));

            _logger.LogInformation($"Attempt to get non-existing {nameof(Contract)} with id {id} not found");
            return NotFound();
        }

        /// <summary>
        /// Создать контракт
        /// </summary>
        /// <param name="contract">Модель контракта</param>
        /// <returns>Сохраненный результат</returns>
        [HttpPost]
        [Produces(typeof(ContractViewModel))]
        public async Task<ActionResult<ContractViewModel>> PostContract(CreateContractArguments contract)
        {
            var result = await _context
                .Contract
                .AddAsync(_mapper.Map<Contract>(contract));
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError($"Attempt to create {nameof(Contract)} was rejected. Error: {e.Message}");
                throw;
            }

            return Ok(_mapper.Map<ContractViewModel>(result.Entity));
        }

        /// <summary>
        /// Обновить контракт с заданным id
        /// </summary>
        /// <param name="id">Id контракта</param>
        /// <param name="contract">Обновленный контракт</param>
        /// <returns>Итоговый вариант контракта</returns>
        [HttpPut("{id}")]
        [Produces(typeof(ContractViewModel))]
        public async Task<ActionResult<ContractViewModel>> PutContract(int id, UpdateContractArguments contract)
        {
            var target = await _context.Contract.FindAsync(id);

            if (target is null)
            {
                _logger.LogInformation($"Attempt to modify a not existing {nameof(Contract)} with id {id}");
                return NotFound();
            }


            var result = _context.Contract.Update(_mapper.Map(contract, target));
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError($"Attempt to update {nameof(Contract)} with id {id} was rejected. Error: {e.Message}");
                throw;
            }


            return Ok(_mapper.Map<ContractViewModel>(result.Entity));
        }

        /// <summary>
        /// Удалить контракт с заданным id
        /// </summary>
        /// <param name="id">id контракта, который нужно удалить</param>
        /// <returns>id удаленного контракта</returns>
        [HttpDelete("{id}")]
        [Produces(typeof(int))]
        public async Task<ActionResult<int>> DeleteContract(int id)
        {
            var contract = await _context.Contract.FindAsync(id);
            if (contract is null)
            {
                _logger.LogInformation($"Attempt to delete not existing {nameof(Contract)} with id {id}");
                return NotFound();
            }

            _context.Contract.Remove(contract);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError($"Attempt to delete {nameof(Contract)} with id {id} was rejected. Error: {e.Message}");
                throw;
            }

            return Ok(id);
        }
    }
}
