using Microsoft.AspNetCore.SignalR;

namespace Paradigmas.SignalR.Lab.Api;

// {"protocol":"json","version":1}

//{"argumenets": ["Hola!!"], "invocationId": "0", "target": "SendMessage", "type": 1 }
public class ChatHub : Hub<IChatClient>
{
    public override async Task OnConnectedAsync()
    {
        await Clients.All.ReceiveMessage($"{Context.ConnectionId} se a unido!");
    }

    public async Task SendMessage(string message)
    {
        await Clients.All.ReceiveMessage($"{Context.ConnectionId} : {message}");
    }
}
public interface IChatClient
{
    Task ReceiveMessage(string message);
}