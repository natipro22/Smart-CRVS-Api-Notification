using AppDiv.CRVS.Application.Interfaces.Persistence.Base;
using AppDiv.CRVS.Domain.Entities.Notification;
using AppDiv.CRVS.Domain.Entities.Notifications;

namespace AppDiv.CRVS.Application.Interfaces.Persistence
{
    public interface IOnlineApplicationRepository : IBaseRepository<OnlineApplication>
    {
        new IQueryable<OnlineApplication> GetAll();
        new Task<OnlineApplication> GetAsync(object id);
        new void Update(OnlineApplication birthNotification);
        Task<string> RandomCodeAsync();
        // Task<DeathNotification> GetByIdAsync(Guid id);
        // Task<List<DeathNotification>> GetMultipleDeathNotifications(List<Guid> Ids);
    }
}