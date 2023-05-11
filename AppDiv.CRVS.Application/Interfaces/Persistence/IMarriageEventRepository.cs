using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDiv.CRVS.Application.Interfaces.Persistence.Base;
using AppDiv.CRVS.Domain.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace AppDiv.CRVS.Application.Interfaces.Persistence
{
    public interface IMarriageEventRepository : IBaseRepository<MarriageEvent>
    {
        public IQueryable<MarriageEvent> GetAllQueryableAsync();
        public void EFUpdate(MarriageEvent marriageEvent);
        public bool exists(Guid id);
        // public DatabaseFacade Database;
         public DatabaseFacade Database {get;}
        public Task InsertOrUpdateAsync(MarriageEvent entity, CancellationToken cancellationToken);
    }
}