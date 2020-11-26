using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billing52Group.Configuration;
using Billing52Group.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Billing52Group.Accounting
{
    public static class Accounter
    {
        private static readonly IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static readonly string _connectionString = _configuration.GetConnectionString("DatabaseConnectionString");
        private static DbContextOptions<ApplicationDbContext> _optionsBuilder =
            new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseMySql(_connectionString).Options;
        private static readonly ApplicationDbContext _context = new ApplicationDbContext(_optionsBuilder);

        public static async Task StartAccounting()
        {
            IEnumerable<int> allContractsIds = await getAllContractIds();
            foreach (var contractId in allContractsIds)
            {
                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;
                var contractAccount = _context.ContractAccount.FirstOrDefault(account =>
                    account.Mm == month && account.Yy == year &&
                    account.ContractId == contractId) ?? await CreateAccountForNewMonth(contractId);
                //contractAccount.Summa = await calculateAccount(contractId);
                contractAccount.Summa = testCalculateAccount(contractId);
                await _context.SaveChangesAsync();
                await BalanceUpdater.UpdateBalance(contractId);
            }
        }

        private static double testCalculateAccount(int contractId)
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            double summa =  _context.ContractAccount.FirstOrDefault(account =>
                account.Mm == month && account.Yy == year &&
                account.ContractId == contractId).Summa;
            summa += 10;
            return summa;
        }
        
        private static async Task<double> calculateAccount(int contractId)
        {
            double summa = 0;
            summa += await tariffAccounting(contractId);
            summa += await serviceAccounting(contractId);
            return summa;
        }

        private static async Task<List<int>> getAllContractIds()
        {
            List<int> contractIds = new List<int>();
            contractIds = await _context.Contract.Select(contract => contract.Id).ToListAsync();
            return contractIds;
        }

        private static async Task<double> tariffAccounting(int contractId)
        {
            DateTime now = DateTime.Now;
            double summa = 0;
            List<ContractTariff> contractTariffs = await _context.ContractTariff
                .Where(tariff => tariff.Date2==null || tariff.Date2>now && tariff.ContractId==contractId).ToListAsync();
            foreach (var contractTariff in contractTariffs)
            {
                DateTime dateStart = contractTariff.Date1;
                if (contractTariff.TariffPlan.ActivationType.Id == 1)
                {
                    summa += contractTariff.TariffPlan.Cost * calculateCountOfDays(dateStart);
                }
                else if (contractTariff.TariffPlan.ActivationType.Id == 2)
                {
                    if (NeedToAccount(contractTariff.Date1))
                        summa += contractTariff.TariffPlan.Cost;
                }
            }
            return summa;
        }

        private static bool NeedToAccount(DateTime dateStart)
        {
            DateTime now = DateTime.Now;
            if ((dateStart.Year == now.Year && dateStart.Month == now.Month) == false)
            {
                if (dateStart.Day > DateTime.DaysInMonth(now.Year, now.Month))
                {
                    if (now.Day == DateTime.DaysInMonth(now.Year, now.Month))
                    {
                        return true;
                    }
                }
                if (dateStart.Day >= now.Day)
                {
                    return true;
                }
            }
            else
            {
                return true;
            }

            return false;
        }

        private static int calculateCountOfDays(DateTime timeStart)
        {
            DateTime now = DateTime.Now;
            int count = 0;
            if (timeStart.Year == now.Year && timeStart.Month == now.Month)
            {
                count += now.Day - timeStart.Day+1;
            }
            else
            {
                count += now.Day;
            }
            return count;
        }

        private static async Task<double> serviceAccounting(int contractId)
        {
            DateTime now = DateTime.Now;
            double summa = 0;
            List<ContractService> contractServices = await _context.ContractService
                .Where(service => service.Date2==null || service.Date2>now && service.ContractId==contractId).ToListAsync();
            foreach (var contractService in contractServices)
            {
                DateTime dateStart = contractService.Date1;
                if (contractService.Service.ActivationType.Id == 1)
                {
                    summa += contractService.Service.Cost * calculateCountOfDays(dateStart);
                }
                else if (contractService.Service.ActivationType.Id == 2)
                {
                    if (NeedToAccount(contractService.Date1))
                        summa += contractService.Service.Cost;
                }
            }
            return summa;
        }
        
        private static async Task<ContractAccount> CreateAccountForNewMonth(int contractId)
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            ContractAccount contractAccountOfNewMonth =
                new ContractAccount {ContractId = contractId, Mm = month, Yy = year, Summa = 0};
            await _context.ContractAccount.AddAsync(contractAccountOfNewMonth);
            await _context.SaveChangesAsync();
            return contractAccountOfNewMonth;
        }
    }
}
