using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Application.Features.Lookups.Query.GetAllLookup;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Application.Mapper;
using AppDiv.CRVS.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Features.Lookups.Query.GetLookupByKey
{

    public class GetLookupByKeyQuery : IRequest<List<LookupByKeyDTO>>
    {
        public string Key { get; set; }
    }

    public class GetLookupByKeyQueryHandler : IRequestHandler<GetLookupByKeyQuery, List<LookupByKeyDTO>>
    {
        private readonly ILookupRepository _lookupRepository;

        public GetLookupByKeyQueryHandler(ILookupRepository lookupQueryRepository)
        {
            _lookupRepository = lookupQueryRepository;
        }
        public async Task<List<LookupByKeyDTO>> Handle(GetLookupByKeyQuery request, CancellationToken cancellationToken)
        {
            var lookups = await _lookupRepository.GetAllWithAsync(x => x.Key == request.Key);
            // var lookups = AllLookups.Where(x => x.Key == request.Key);
            var formatedLookup = lookups.Select(lo => new LookupByKeyDTO
            {
                id = lo.Id,
                Key = lo.Key,
                Value = lo.Value.Value<string>("en")
            });

            return formatedLookup.ToList();
        }
    }
}




