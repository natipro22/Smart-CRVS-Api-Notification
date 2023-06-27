using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Domain.Entities.Notifications;
using Microsoft.EntityFrameworkCore;

namespace AppDiv.CRVS.Infrastructure.Persistence
{
    public class BirthNotificationRepository : BaseNotificationRepository<BirthNotification>, IBirthNotificationRepository
    {
        private readonly NotificationDbContext dbContext;

        public BirthNotificationRepository(NotificationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

    }
}