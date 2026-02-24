namespace EShop.SignalR.Services
{
    public interface ISignalRService
    {
        Task<int> GetTotalMessageCountByReceiverId(string id);
        Task<int> GetTotalCommentCount();
    }
}
