using Microsoft.AspNetCore.SignalR;
using Models.Enums;

namespace Business.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendMessage(string tableName, NotificationTypoEnum typo, object data)
        {
            await Clients.All.SendAsync("ReceiveMessage", tableName, typo, data);
        }
    }
}
