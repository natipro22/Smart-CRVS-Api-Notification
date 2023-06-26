using AppDiv.CRVS.Application.Common;
using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Application.Features.DeathNotifications.Commands.Create;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Application.Mapper;
using AppDiv.CRVS.Domain.Entities;
using AppDiv.CRVS.Domain.Entities.Notifications;
using AppDiv.CRVS.Domain.Repositories;
using MediatR;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Features.Lookups.Command.Update
{
    public class UpdateDeathNotificationCommandHandler : IRequestHandler<UpdateDeathNotificationCommand, BaseResponse>
    {
        private readonly IDeathNotificationRepository _deathNotificationRepository;
        public UpdateDeathNotificationCommandHandler(IDeathNotificationRepository deathNotificationRepository)
        {
            _deathNotificationRepository = deathNotificationRepository;
        }
        public async Task<BaseResponse> Handle(UpdateDeathNotificationCommand request, CancellationToken cancellationToken)
        {
            var response  = new BaseResponse();
            // var customerEntity = CustomerMapper.Mapper.Map<Customer>(request);
            var deathNotification = CustomMapper.Mapper.Map<DeathNotification>(request);
            try
            {
                _deathNotificationRepository.Update(deathNotification);
                await _deathNotificationRepository.SaveChangesAsync(cancellationToken);
                response.Updated("Death Notification");
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }
            return response;
        }
    }
}