

using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Domain.Entities;

namespace AppDiv.CRVS.Infrastructure.Persistence
{
    public class WorkflowRepository : BaseRepository<Workflow>, IWorkflowRepository
    {
        public WorkflowRepository(CRVSDbContext dbContext) : base(dbContext)
        {
        }

        async Task<Workflow> IWorkflowRepository.GetByIdAsync(Guid id)
        {
            return await base.GetAsync(id);
        }
    }
}