using System.Linq;
using AppDiv.CRVS.Application.Exceptions;
using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Application.Mapper;
using AppDiv.CRVS.Domain.Entities.Notifications;
using AppDiv.CRVS.Domain.Repositories;
using MediatR;
using ApplicationException = AppDiv.CRVS.Application.Exceptions.ApplicationException;
using AppDiv.CRVS.Application.Interfaces.Persistence;

namespace AppDiv.CRVS.Application.Features.BirthNotifications.Commands.Create
{

    public class CreateBirthNotificationCommandHandler : IRequestHandler<CreateBirthNotificationCommand, CreateBirthNotificationComandResponse>
    {
        private readonly IBirthNotificationRepository _birthNotificationRepository;
        private readonly ILookupRepository _lookupRepository;
        private readonly IAddressLookupRepository _addressRepository;

        public CreateBirthNotificationCommandHandler(IBirthNotificationRepository birthNotificationRepository, 
                                                    ILookupRepository lookupRepository, 
                                                    IAddressLookupRepository addressRepository)
        {
            _birthNotificationRepository = birthNotificationRepository;
            _lookupRepository = lookupRepository;
            _addressRepository = addressRepository;
        }
        public async Task<CreateBirthNotificationComandResponse> Handle(CreateBirthNotificationCommand request, CancellationToken cancellationToken)
        {
            var CreateBirthNotificationComandResponse = new CreateBirthNotificationComandResponse();

            var validator = new CreateBirthNotificationComadValidator(_birthNotificationRepository, _lookupRepository, _addressRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            //Check and log validation errors
            if (validationResult.Errors.Count > 0)
            {
                CreateBirthNotificationComandResponse.Success = false;
                CreateBirthNotificationComandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                    CreateBirthNotificationComandResponse.ValidationErrors.Add(error.ErrorMessage);
                CreateBirthNotificationComandResponse.Message = CreateBirthNotificationComandResponse.ValidationErrors[0];
            }
            if (CreateBirthNotificationComandResponse.Success)
            {
                //
                var birthNotification = CustomMapper.Mapper.Map<BirthNotification>(request.BirthNotification);
                await _birthNotificationRepository.InsertAsync(birthNotification, cancellationToken);
                var result = await _birthNotificationRepository.SaveChangesAsync(cancellationToken);       
            }
            return CreateBirthNotificationComandResponse;
        }
    }
}
