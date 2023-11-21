using AppDiv.CRVS.Application.Common;
using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Application.Mapper;
using AppDiv.CRVS.Domain.Entities;
using AppDiv.CRVS.Domain.Entities.Notification;
using AppDiv.CRVS.Domain.Entities.Notifications;
using AppDiv.CRVS.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Features.OnlineApplications.Query.GetAllOnlineApplication

{
    // Get all birth notification query.
    public record GetAllOnlineApplicationQuery : IRequest<PaginatedList<OnlineApplicationDTO>>
    {
        public int? PageCount { set; get; } = 1!;
        public int? PageSize { get; set; } = 10!;
    }

    public class GetAllOnlineApplicationQueryHandler : IRequestHandler<GetAllOnlineApplicationQuery, PaginatedList<OnlineApplicationDTO>>
    {
        private readonly IOnlineApplicationRepository _onlineApplicationRepository;

        public GetAllOnlineApplicationQueryHandler(IOnlineApplicationRepository onlineApplicationRepository)
        {
            _onlineApplicationRepository = onlineApplicationRepository;
        }
        public async Task<PaginatedList<OnlineApplicationDTO>> Handle(GetAllOnlineApplicationQuery request, CancellationToken cancellationToken)
        {
            return await _onlineApplicationRepository.GetAll()
                                .PaginateAsync<OnlineApplication, OnlineApplicationDTO>(request.PageCount ?? 1, request.PageSize ?? 10);
        }
    }
}