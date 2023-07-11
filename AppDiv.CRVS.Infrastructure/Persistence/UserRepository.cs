using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Domain;


namespace AppDiv.CRVS.Infrastructure.Persistence
{
    public class UserRepository : BaseRepository<ApplicationUser>, IUserRepository
    {
        private readonly CRVSDbContext _dbContext;

        public UserRepository(CRVSDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }
          public IQueryable<ApplicationUser> GetAllQueryableAsync()
        {

            return _dbContext.Users.AsQueryable();
        }
        public bool CheckAny(Guid issuerId)
        {
            return _dbContext.Users.Any(u => u.Id == issuerId.ToString());
        }


    }
}