using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Domain.Entities.Notifications;
using Microsoft.EntityFrameworkCore;

namespace AppDiv.CRVS.Infrastructure.Persistence
{
    public class DeathNotificationRepository : BaseNotificationRepository<DeathNotification>, IDeathNotificationRepository
    {
        private readonly NotificationDbContext dbContext;

        public DeathNotificationRepository(NotificationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

    }
}