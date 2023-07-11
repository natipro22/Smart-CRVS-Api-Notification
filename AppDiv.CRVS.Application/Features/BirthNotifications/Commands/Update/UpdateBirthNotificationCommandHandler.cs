using AppDiv.CRVS.Application.Common;
using AppDiv.CRVS.Application.Features.BirthNotifications.Commands.Update;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Application.Mapper;
using AppDiv.CRVS.Domain.Entities.Notifications;
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
            try
            {
                // Validate the request inputs.
                var validator = new UpdateBirthNotificationCommandValidator(_birthNotificationRepository, _lookupRepository, _addressRepository, _userRepository);
                var validationResult = await validator.ValidateAsync(request, cancellationToken);
    
                //Check and log validation errors
                if (!validationResult.IsValid)
                {
                    response.BadRequest(validationResult.Errors);
                }
                else
                {
                    try
                    {
                        // Map to the model entity.
                        var birthNotification = CustomMapper.Mapper.Map<BirthNotification>(request);
                        // Update the data.
                        _birthNotificationRepository.Update(birthNotification);
                        await _birthNotificationRepository.SaveChangesAsync(cancellationToken);
                        // Set the response to updated.
                        response.Updated("Death Notification");
                    }
                    catch (Exception exp)
                    {
                        throw new ApplicationException(exp.Message);
                    }
                }
            }
            catch (System.Exception ex)
            {
                // Set the response to bad request on exception.
                response.BadRequest(ex.Message);
            }
            return response;

        }
    }
}