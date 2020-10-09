using Billing52Group.Server.Configuration;
using Billing52Group.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing52Group.Server.Controllers.V1
{
    [Route("[area]/[controller]")]
    [ApiController]
    public sealed class ContractsController : V1ControllerBase
    {
        readonly Billing52GroupContext _context;
        readonly ILogger<ContractsController> _logger;

        public ContractsController(Billing52GroupContext context, ILogger<ContractsController> logger)
        {
            _context = context;
            _logger = logger;
        }


        /// <summary>
        /// Вернуть все контракты
        /// </summary>
        /// <returns>Все контракты, зарегистрированные в системе</returns>
        [HttpGet]
        [Produces(typeof(IEnumerable<Contract>))]
        public async Task<ActionResult<IEnumerable<Contract>>> GetAll()
        {
            return await _context.Contract.ToListAsync();
        }

        /// <summary>
        /// Получить контракт по id
        /// </summary>
        /// <param name="id">id контракта</param>
        /// <returns>Контракт с заданным id</returns>
        [HttpGet("{id}")]
        [Produces(typeof(Contract))]
        public async Task<ActionResult<Contract>> Get(int id)
        {
            var contract = await _context.Contract.FindAsync(id);
            if (contract is null)
            {
                _logger.LogInformation($"Contract with id {id} not found");
                return NotFound();
            }
            return contract;
        }

        /// <summary>
        /// Создать контракт
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces(typeof(Contract))]
        public async Task<ActionResult<Contract>> PostContract(Contract contract)
        {
            await _context.Contract.AddAsync(contract);
            await _context.SaveChangesAsync();
            return Ok(contract);
        }

        /// <summary>
        /// Обновить контракт с заданным id
        /// </summary>
        /// <param name="id">Id контракта</param>
        /// <param name="contract">Обновленный контракт</param>
        /// <returns>Итоговый вариант контракта</returns>
        [HttpPut("{id}")]
        [Produces(typeof(Contract))]
        public async Task<IActionResult> PutContract(int id, Contract contract)
        {
            // @TODO поменять Contract на другую модель
            if (id != contract.Id)
            {
                _logger.LogInformation("Contract id is not equal updatedEntity.id");
                return BadRequest();
            }

            if (!ContractExists(id))
            {
                _logger.LogInformation($"Attempt to modify a non-existent contract with id {id}");
                return NotFound();
            }

            _context.Entry(contract).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(contract);
        }

        // DELETE: api/Contracts/5
        [HttpDelete("{id}")]
        [Produces(typeof(int))]
        public async Task<ActionResult<int>> DeleteContract(int id)
        {
            var contract = await _context.Contract.FindAsync(id);
            if (contract is null)
            {
                _logger.LogInformation($"Contact with id {id} not found");
                return NotFound();
            }

            try
            {
                _context.Contract.Remove(contract);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError($"Attempt to delete contract with id {id} was rejected. Error: {e.Message}");
                throw;
            }

            return Ok(id);
        }

        bool ContractExists(int id)
        {
            return _context.Contract.Any(e => e.Id == id);
        }
    }
}
