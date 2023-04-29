using AppDiv.CRVS.Application.Interfaces.Persistence.Base;
using AppDiv.CRVS.Domain.Entities;

namespace AppDiv.CRVS.Application.Interfaces.Persistence
{
    public interface IGroupRepository : IBaseRepository<UserGroup>
    {
        // Task<UserGroup> GetByIdAsync(Guid id);
        Task<List<UserGroup>> GetMultipleUserGroups(List<Guid> userIds);
    }
}