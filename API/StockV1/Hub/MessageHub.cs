using Microsoft.AspNetCore.SignalR;
using StockV1.Models;

namespace StockV1.Hub
{
    public class MessageHub : Hub<IMessageHubClient>
    {
        public async Task SendStocksToUser(Stock message)
        {
            await Clients.All.SendStocksToUser(message);
        }
    }
}
