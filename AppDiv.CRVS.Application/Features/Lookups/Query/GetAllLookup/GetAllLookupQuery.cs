
using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Application.Mapper;
using AppDiv.CRVS.Domain.Entities;
using AppDiv.CRVS.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Features.Lookups.Query.GetAllLookup

{
    // Customer query with List<Customer> response
    public record GetAllLookupQuery : IRequest<List<LookupForGridDTO>>
    {

    }

    public class GetAllLookupQueryHandler : IRequestHandler<GetAllLookupQuery, List<LookupForGridDTO>>
    {
        private readonly ILookupRepository _lookupRepository;

        public GetAllLookupQueryHandler(ILookupRepository lookupQueryRepository)
        {
            _lookupRepository = lookupQueryRepository;
        }
        public async Task<List<LookupForGridDTO>> Handle(GetAllLookupQuery request, CancellationToken cancellationToken)
        {
            var LookupList = await _lookupRepository.GetAllAsync();
            var lookups = CustomMapper.Mapper.Map<List<LookupDTO>>(LookupList);
            // return lookups;

            // return (List<Customer>)await _customerQueryRepository.GetAllAsync();

            var formatedLookup = lookups.Select(lo => new LookupForGridDTO
            {
                id = lo.Id,
                Key = lo.Key,
                Value = lo?.Value["en"]?.ToString(),
                StatisticCode = lo?.StatisticCode,
                Code = lo?.Code


            });
            return formatedLookup.ToList();
        }
    }
}