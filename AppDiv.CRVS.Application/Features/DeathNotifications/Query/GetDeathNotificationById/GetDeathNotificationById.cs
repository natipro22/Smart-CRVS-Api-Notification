
using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Application.Features.DeathNotifications.Query.GetAllDeathNotification;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Application.Mapper;
using AppDiv.CRVS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Features.DeathNotifications.Query.GetDeathNotificationById
{
    // Customer GetDeathNotificationbyId with  response
    public class GetDeathNotificationById : IRequest<DeathNotificationDTO>
    {
        public Guid Id { get; private set; }

        public GetDeathNotificationById(Guid Id)
        {
            this.Id = Id;
        }

    }

    public class GetDeathNotificationByIdHandler : IRequestHandler<GetDeathNotificationById, DeathNotificationDTO>
    {
        private readonly IDeathNotificationRepository _deathNotificationRepository;

        public GetDeathNotificationByIdHandler(IDeathNotificationRepository deathNotificationRepository)
        {
            
            _deathNotificationRepository = deathNotificationRepository;
        }
        public async Task<DeathNotificationDTO> Handle(GetDeathNotificationById request, CancellationToken cancellationToken)
        {
            var selectedDeathNotification = await _deathNotificationRepository.GetAsync(request.Id);
            return CustomMapper.Mapper.Map<DeathNotificationDTO>(selectedDeathNotification);
        }
    }
}