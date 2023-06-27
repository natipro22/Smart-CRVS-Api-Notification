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

namespace AppDiv.CRVS.Application.Features.BirthNotifications.Query.GetAllBirthNotification

{
    // Customer query with List<Customer> response
    public record GetAllBirthNotificationQuery : IRequest<PaginatedList<BirthNotificationDTO>>
    {
        public int? PageCount { set; get; } = 1!;
        public int? PageSize { get; set; } = 10!;
    }

    public class GetAllBirthNotificationQueryHandler : IRequestHandler<GetAllBirthNotificationQuery, PaginatedList<BirthNotificationDTO>>
    {
        private readonly IBirthNotificationRepository _birthNotificationRepository;

        public GetAllBirthNotificationQueryHandler(IBirthNotificationRepository birthNotificationRepository)
        {
            _birthNotificationRepository = birthNotificationRepository;
        }
        public async Task<PaginatedList<BirthNotificationDTO>> Handle(GetAllBirthNotificationQuery request, CancellationToken cancellationToken)
        {
            return await _birthNotificationRepository.GetAll()
                                .PaginateAsync<BirthNotification, BirthNotificationDTO>(request.PageCount ?? 1, request.PageSize ?? 10);
        }
    }
}