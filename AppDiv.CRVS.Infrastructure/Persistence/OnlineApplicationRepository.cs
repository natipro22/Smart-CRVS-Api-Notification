using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Domain.Entities.Notification;
using AppDiv.CRVS.Domain.Entities.Notifications;
using AppDiv.CRVS.Utility.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AppDiv.CRVS.Infrastructure.Persistence
{
    public class OnlineApplicationRepository : BaseNotificationRepository<OnlineApplication>, IOnlineApplicationRepository
    {
        private readonly NotificationDbContext _dbContext;

        public OnlineApplicationRepository(NotificationDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public override IQueryable<OnlineApplication> GetAll()
        {
            return base.GetAll();
        }
        public override void Update(OnlineApplication birthNotification)
        {
            this._dbContext.Update(birthNotification);
        }

        public override async Task<OnlineApplication> GetAsync(object id)
        {
            return await base.GetAsync(id);
        }

    }
}