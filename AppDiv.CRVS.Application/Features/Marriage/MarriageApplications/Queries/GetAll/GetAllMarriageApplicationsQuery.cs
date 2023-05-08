using AppDiv.CRVS.Application.Common;
using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Application.Mapper;
using AppDiv.CRVS.Domain.Entities;
using AppDiv.CRVS.Domain.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Features.MarriageApplications.Query
{
    // Customer query with List<Customer> response
    public record GetAllMarriageApplicationsQuery : IRequest<PaginatedList<MarriageApplicationGridDTO>>
    {
        public int? PageCount { set; get; } = 1!;
        public int? PageSize { get; set; } = 10!;
    }

    public class GetAllMarriageApplicationsQueryHandler : IRequestHandler<GetAllMarriageApplicationsQuery, PaginatedList<MarriageApplicationGridDTO>>
    {
        private readonly IMarriageApplicationRepository _MarriageApplicationsRepository;
        private readonly IMapper _mapper;

        public GetAllMarriageApplicationsQueryHandler(IMarriageApplicationRepository MarriageApplicationsQueryRepository , IMapper mapper)
        {
            _MarriageApplicationsRepository = MarriageApplicationsQueryRepository;
            _mapper = mapper;
        }
        public async Task<PaginatedList<MarriageApplicationGridDTO>> Handle(GetAllMarriageApplicationsQuery request, CancellationToken cancellationToken)
        {
           
            return await PaginatedList<MarriageApplicationGridDTO>
                            .CreateAsync(
                               await _MarriageApplicationsRepository.GetAll().ProjectToListAsync<MarriageApplicationGridDTO>(_mapper.ConfigurationProvider)
                                , request.PageCount ?? 1, request.PageSize ?? 10);
            // var MarriageApplicationsResponse = CustomMapper.Mapper.Map<List<MarriageApplicationsDTO>>(MarriageApplicationsList);
            // return MarriageApplicationsResponse;
        }
    }
}