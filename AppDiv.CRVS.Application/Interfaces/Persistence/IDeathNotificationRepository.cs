using AppDiv.CRVS.Application.Interfaces.Persistence.Base;
using AppDiv.CRVS.Domain.Entities.Notifications;

namespace AppDiv.CRVS.Application.Interfaces.Persistence
{
    public interface IDeathNotificationRepository : IBaseRepository<DeathNotification>
    {
        new IQueryable<DeathNotification> GetAll();
        new Task<DeathNotification> GetAsync(object id);
    }
}