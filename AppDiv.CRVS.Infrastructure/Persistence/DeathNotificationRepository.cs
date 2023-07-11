using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Domain.Entities.Notifications;
using AppDiv.CRVS.Utility.Contracts;
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

        public override IQueryable<DeathNotification> GetAll()
        {
            return base.GetAll()
                            .Include(d => d.Registrar)
                            .Include(d => d.Deceased);
                            // .Include(d => d.Issuer);
        }
        public override async Task<DeathNotification> GetAsync(object id)
        {
            var toInclude = new Dictionary<String, NavigationPropertyType>
                                    {
                                        {"Registrar", NavigationPropertyType.REFERENCE},
                                        // {"Issuer", NavigationPropertyType.REFERENCE},
                                        {"Deceased", NavigationPropertyType.REFERENCE}
                                    };
            return await base.GetWithAsync(id,toInclude);
        }

    }
}