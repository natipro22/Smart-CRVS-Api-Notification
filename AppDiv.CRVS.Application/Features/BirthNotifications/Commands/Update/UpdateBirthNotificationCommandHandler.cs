using AppDiv.CRVS.Application.Common;
using AppDiv.CRVS.Application.Features.BirthNotifications.Commands.Update;
using AppDiv.CRVS.Application.Interfaces;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Application.Mapper;
using AppDiv.CRVS.Domain.Entities.Notifications;
using AppDiv.CRVS.Domain.Repositories;
using MediatR;

namespace AppDiv.CRVS.Application.Features.Lookups.Command.Update
{
    public class UpdateBirthNotificationCommandHandler : IRequestHandler<UpdateBirthNotificationCommand, BaseResponse>
    {
        private readonly IBirthNotificationRepository _birthNotificationRepository;
        private readonly ILookupRepository _lookupRepository;
        private readonly IAddressLookupRepository _addressRepository;
        private readonly IUserRepository _userRepository;
        public UpdateBirthNotificationCommandHandler(IBirthNotificationRepository birthNotificationRepository,
                                                    ILookupRepository lookupRepository, 
                                                    IAddressLookupRepository addressRepository,
                                                    IUserRepository userRepository)
        {
            _birthNotificationRepository = birthNotificationRepository;
            _lookupRepository = lookupRepository;
            _addressRepository = addressRepository;
            _userRepository = userRepository;
        }
        public async Task<BaseResponse> Handle(UpdateBirthNotificationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            var validator = new UpdateBirthNotificationComadValidator(_birthNotificationRepository, _lookupRepository, _addressRepository, _userRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            //Check and log validation errors
            if (validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                    response.ValidationErrors.Add(error.ErrorMessage);
                response.Message = response.ValidationErrors[0];
            }
            if (response.Success)
            {
                try
                {
                    var birthNotification = CustomMapper.Mapper.Map<BirthNotification>(request);
                    _birthNotificationRepository.Update(birthNotification);
                    await _birthNotificationRepository.SaveChangesAsync(cancellationToken);
                    response.Updated("Death Notification");
                }
                catch (Exception exp)
                {
                    throw new ApplicationException(exp.Message);
                }
            }
            return response;

        }
    }
}