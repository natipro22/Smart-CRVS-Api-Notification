using AppDiv.CRVS.Application.Common;
using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Application.Mapper;
using AppDiv.CRVS.Domain.Entities;
using AppDiv.CRVS.Domain.Entities.Notifications;
using AppDiv.CRVS.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Features.DeathNotifications.Query.GetAllDeathNotification

{
    // Customer query with List<Customer> response
    public record GetAllDeathNotificationQuery : IRequest<PaginatedList<DeathNotificationDTO>>
    {
        public int? PageCount { set; get; } = 1!;
        public int? PageSize { get; set; } = 10!;
    }

    public class GetAllDeathNotificationQueryHandler : IRequestHandler<GetAllDeathNotificationQuery, PaginatedList<DeathNotificationDTO>>
    {
        private readonly IDeathNotificationRepository _deathNotificationRepository;

        public GetAllDeathNotificationQueryHandler(IDeathNotificationRepository deathNotificationRepository)
        {
            _deathNotificationRepository = deathNotificationRepository;
        }
        public async Task<PaginatedList<DeathNotificationDTO>> Handle(GetAllDeathNotificationQuery request, CancellationToken cancellationToken)
        {
            var deathNotificationlist = _deathNotificationRepository.GetAll();
            return await _deathNotificationRepository.GetAll()
                                .PaginateAsync<DeathNotification, DeathNotificationDTO>(request.PageCount ?? 1, request.PageSize ?? 10);
        }
    }
}