using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Billing52Group.Accounting
{
    public class BackGroundAccounter : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (stoppingToken.IsCancellationRequested == false)
            {
                await Accounter.StartAccounting();               
                await Task.Delay(5000, stoppingToken);
            }
            throw new System.NotImplementedException();
        }
    }
}
