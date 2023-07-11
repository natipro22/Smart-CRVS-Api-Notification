
using AppDiv.CRVS.Application.Interfaces.Persistence.Base;
using AppDiv.CRVS.Domain;
using AppDiv.CRVS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Interfaces.Persistence
{
    // Interface for CustomerQueryRepository
    public interface IUserRepository : IBaseRepository<ApplicationUser>
    {
         IQueryable<ApplicationUser> GetAllQueryableAsync();
         bool CheckAny(Guid issuerId);
    }
}
