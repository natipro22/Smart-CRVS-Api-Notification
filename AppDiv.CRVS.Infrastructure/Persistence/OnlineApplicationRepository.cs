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
        public override void Update(OnlineApplication application)
        {
            this._dbContext.Update(application);
        }

        public override async Task<OnlineApplication> GetAsync(object id)
        {
            return await base.GetAsync(id);
        }

        public async Task<string> RandomCodeAsync()
        {
            Random random = new Random();
            // Generate a random five-character string
            string randomString = GenerateRandomString(random, 5); 
            bool exists = await _dbContext.OnlineApplications
                            .Select(a => a.ApplicationCode)
                            .AnyAsync(c =>  c == randomString);
            if (!exists)
                return randomString;
            else
                return await RandomCodeAsync();
        }

        static string GenerateRandomString(Random random, int length)
        {
            const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            char[] randomChars = new char[length];
            for (int i = 0; i < length; i++)
            {
                randomChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(randomChars);
        }

    }
}