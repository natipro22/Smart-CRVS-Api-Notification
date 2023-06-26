using AppDiv.CRVS.Application.Interfaces.Persistence.Base;
using AppDiv.CRVS.Domain.Entities.Notifications;

namespace AppDiv.CRVS.Application.Interfaces.Persistence
{
    public interface IDeathNotificationRepository : IBaseRepository<DeathNotification>
    {
        // Task<DeathNotification> GetByIdAsync(Guid id);
        // Task<List<DeathNotification>> GetMultipleDeathNotifications(List<Guid> Ids);
    }
}