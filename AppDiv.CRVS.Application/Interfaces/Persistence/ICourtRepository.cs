
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDiv.CRVS.Application.Interfaces.Persistence.Base;
using AppDiv.CRVS.Domain.Entities;

namespace AppDiv.CRVS.Application.Interfaces.Persistence
{
    public interface ICourtRepository : IBaseRepository<Court>
    {
        Task<Court> GetByIdAsync(Guid id);
        public bool CourtCaseExists(Guid id);

    }
}