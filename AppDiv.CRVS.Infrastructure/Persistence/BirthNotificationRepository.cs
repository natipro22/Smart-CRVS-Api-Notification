using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Domain.Entities.Notifications;
using AppDiv.CRVS.Utility.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AppDiv.CRVS.Infrastructure.Persistence
{
    public class BirthNotificationRepository : BaseNotificationRepository<BirthNotification>, IBirthNotificationRepository
    {
        private readonly NotificationDbContext _dbContext;

        public BirthNotificationRepository(NotificationDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public override IQueryable<BirthNotification> GetAll()
        {
            return base.GetAll()
                            .Include(b => b.Mother)
                            .Include(b => b.Childrens)
                            .Include(b => b.Attendant);
        }
        public override void Update(BirthNotification birthNotification)
        {
            this._dbContext.Update(birthNotification);
        }

        public override async Task<BirthNotification> GetAsync(object id)
        {
            var toInclude = new Dictionary<String, NavigationPropertyType>
                                    {
                                        {"Mother", NavigationPropertyType.REFERENCE},
                                        {"Attendant", NavigationPropertyType.REFERENCE},
                                        {"Childrens", NavigationPropertyType.COLLECTION}
                                    };
            return await base.GetWithAsync(id,toInclude);
        }

    }
}