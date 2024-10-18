using Microsoft.AspNetCore.SignalR;

namespace Paradigmas.SignalR.Lab.Api;

public class NotificationHub : Hub<IRecieveNotification>
{
    public override async Task OnConnectedAsync()
    {
        await Clients.Client(Context.ConnectionId).ReceiveNotification($"Gracias, conectando{Context.User?.Identity.Name}");
        await base.OnConnectedAsync();
    }
}

public interface IRecieveNotification
{
    Task ReceiveNotification(string message);
}