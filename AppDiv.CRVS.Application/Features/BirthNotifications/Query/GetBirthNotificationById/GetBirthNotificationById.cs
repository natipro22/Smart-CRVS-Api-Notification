
using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Application.Features.BirthNotifications.Query.GetAllBirthNotification;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Application.Mapper;
using AppDiv.CRVS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Features.BirthNotifications.Query.GetBirthNotificationById
{
    // Customer GetBirthNotificationbyId with  response
    public class GetBirthNotificationById : IRequest<BirthNotificationDTO>
    {
        public Guid Id { get; private set; }

        public GetBirthNotificationById(Guid Id)
        {
            this.Id = Id;
        }

    }

    public class GetBirthNotificationByIdHandler : IRequestHandler<GetBirthNotificationById, BirthNotificationDTO>
    {
        private readonly IBirthNotificationRepository _birthNotificationRepository;

        public GetBirthNotificationByIdHandler(IBirthNotificationRepository birthNotificationRepository)
        {
            
            _birthNotificationRepository = birthNotificationRepository;
        }
        public async Task<BirthNotificationDTO> Handle(GetBirthNotificationById request, CancellationToken cancellationToken)
        {
            var selectedBirthNotification = await _birthNotificationRepository.GetAsync(request.Id);
            return CustomMapper.Mapper.Map<BirthNotificationDTO>(selectedBirthNotification);
        }
    }
}