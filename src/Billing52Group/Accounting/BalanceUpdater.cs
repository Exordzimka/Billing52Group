using System;
using System.Linq;
using System.Threading.Tasks;
using Billing52Group.Configuration;
using Billing52Group.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Billing52Group.Accounting
{
    public static class BalanceUpdater
    {
        private static readonly IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static readonly string _connectionString = _configuration.GetConnectionString("DatabaseConnectionString");
        private static DbContextOptions<ApplicationDbContext> _optionsBuilder =
            new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseMySql(_connectionString).Options;
        private static readonly ApplicationDbContext _context = new ApplicationDbContext(_optionsBuilder);
        
        public static async Task UpdateBalance(int contractId)
        {
            ContractBalance balance;
            DateTime now = DateTime.Now;
            int year = now.Year;
            int month = now.Month;
            balance = _context.ContractBalance.FirstOrDefault(balance => balance.Mm == month && balance.Yy == year &&
                                                                         balance.ContractId == contractId) ?? await CreateBalanceForNewMonth(contractId);
            balance.Summa = await CalculateBalance(balance);
            await _context.SaveChangesAsync();
        }

        private static async Task<double> CalculateBalance(ContractBalance contractBalance)
        {
            double summa = 0;
            summa += await GetBalanceOfPreviousMonth(contractBalance.ContractId);
            summa += await CalculatePayments(contractBalance.ContractId);
            summa += await CalculateCharges(contractBalance.ContractId);
            summa += await GetAccountForMonth(contractBalance.ContractId);
            return summa;
        }

        private static async Task<double> CalculateCharges(int contractId)
        {
            double summOfCharges = 0;
            
            await _context.ContractCharge.Where(charge =>
                charge.ContractId == contractId &&
                charge.Date.Year == DateTime.Now.Year &&
                charge.Date.Month == DateTime.Now.Month).ForEachAsync(charge => summOfCharges-=charge.Summa);
            return summOfCharges;
        }
        
        private static async Task<double> CalculatePayments(int contractId)
        {
            double summOfPayments = 0;
            
            await _context.ContractPayment.Where(payment =>
                payment.ContractId == contractId &&
                payment.Date.Value.Year == DateTime.Now.Year &&
                payment.Date.Value.Month == DateTime.Now.Month).ForEachAsync(payment => summOfPayments+=payment.Summa);
            return summOfPayments;
        }

        private static async Task<double> GetAccountForMonth(int contractId)
        {
            ContractAccount contractAccount = await _context.ContractAccount.FirstOrDefaultAsync(account =>
                account.ContractId == contractId && account.Mm == DateTime.Now.Month &&
                account.Yy == DateTime.Now.Year);
            return contractAccount?.Summa*(-1) ?? 0;
        }

        private static async Task<double> GetBalanceOfPreviousMonth(int contractId)
        {
            DateTime previousMonthDate = DateTime.Now;
            previousMonthDate = previousMonthDate.AddMonths(-1);
            ContractBalance contractBalanceOfPreviousMonth = await _context.ContractBalance.FirstOrDefaultAsync(
                balance => balance.ContractId == contractId && balance.Mm==previousMonthDate.Month && 
                           balance.Yy==previousMonthDate.Year);
            return contractBalanceOfPreviousMonth?.Summa ?? 0;
        }

        private static async Task<ContractBalance> CreateBalanceForNewMonth(int contractId)
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            ContractBalance contractBalanceOfNewMonth =
                new ContractBalance {ContractId = contractId, Mm = month, Yy = year, Summa = 0};
            await _context.ContractBalance.AddAsync(contractBalanceOfNewMonth);
            await _context.SaveChangesAsync();
            return contractBalanceOfNewMonth;
        }
    }
}
