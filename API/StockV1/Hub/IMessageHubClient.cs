using StockV1.Models;

namespace StockV1.Hub
{
    public interface IMessageHubClient
    {
        Task SendStocksToUser(Stock message);
    }
}
