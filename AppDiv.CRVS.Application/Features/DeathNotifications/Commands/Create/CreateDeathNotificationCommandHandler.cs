using System.Linq;
using AppDiv.CRVS.Application.Exceptions;
using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Application.Mapper;
using AppDiv.CRVS.Domain.Entities.Notifications;
using AppDiv.CRVS.Domain.Repositories;
using MediatR;
using ApplicationException = AppDiv.CRVS.Application.Exceptions.ApplicationException;
using AppDiv.CRVS.Application.Interfaces.Persistence;

namespace AppDiv.CRVS.Application.Features.DeathNotifications.Commands.Create
{

    public class CreateDeathNotificationCommandHandler : IRequestHandler<CreateDeathNotificationCommand, CreateDeathNotificationComandResponse>
    {
        private readonly IDeathNotificationRepository _deathNotificationRepository;
        public CreateDeathNotificationCommandHandler(IDeathNotificationRepository deathNotificationRepository)
        {
            _deathNotificationRepository = deathNotificationRepository;
        }
        public async Task<CreateDeathNotificationComandResponse> Handle(CreateDeathNotificationCommand request, CancellationToken cancellationToken)
        {
            var CreateDeathNotificationComandResponse = new CreateDeathNotificationComandResponse();

            var validator = new CreateDeathNotificationComadValidator(_deathNotificationRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            //Check and log validation errors
            if (validationResult.Errors.Count > 0)
            {
                CreateDeathNotificationComandResponse.Success = false;
                CreateDeathNotificationComandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                    CreateDeathNotificationComandResponse.ValidationErrors.Add(error.ErrorMessage);
                CreateDeathNotificationComandResponse.Message = CreateDeathNotificationComandResponse.ValidationErrors[0];
            }
            if (CreateDeathNotificationComandResponse.Success)
            {
                //
                var deathNotification = CustomMapper.Mapper.Map<DeathNotification>(request.DeathNotification);
                await _deathNotificationRepository.InsertAsync(deathNotification, cancellationToken);
                var result = await _deathNotificationRepository.SaveChangesAsync(cancellationToken);       
            }
            return CreateDeathNotificationComandResponse;
        }
    }
}
