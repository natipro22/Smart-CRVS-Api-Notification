using AppDiv.CRVS.Application.Interfaces.Persistence.Base;
using AppDiv.CRVS.Domain.Entities.Notifications;

namespace AppDiv.CRVS.Application.Interfaces.Persistence
{
    public interface IBirthNotificationRepository : IBaseRepository<BirthNotification>
    {
        new IQueryable<BirthNotification> GetAll();
        new Task<BirthNotification> GetAsync(object id);
        new void Update(BirthNotification birthNotification);
        // Task<DeathNotification> GetByIdAsync(Guid id);
        // Task<List<DeathNotification>> GetMultipleDeathNotifications(List<Guid> Ids);
    }
}