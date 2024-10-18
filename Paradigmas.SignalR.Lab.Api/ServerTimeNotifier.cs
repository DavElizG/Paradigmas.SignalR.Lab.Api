using Microsoft.AspNetCore.SignalR;
using System.Data;

namespace Paradigmas.SignalR.Lab.Api
{
    public class ServerTimeNotifier : BackgroundService
    {

        private static readonly TimeSpan Period = TimeSpan.FromSeconds(5);

        private readonly IHubContext<NotificationHub, IRecieveNotification> _context;

        public ServerTimeNotifier(IHubContext<NotificationHub, IRecieveNotification> hubContext )
        {
            _context = hubContext;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(Period);

            while (!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
            {
                var dateTime = DateTime.Now;

                await _context.Clients.All.ReceiveNotification($"Server Time = {dateTime}");
            }

        }
    }
}