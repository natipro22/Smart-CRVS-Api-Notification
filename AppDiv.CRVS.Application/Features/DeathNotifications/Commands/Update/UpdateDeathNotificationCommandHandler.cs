using AppDiv.CRVS.Application.Common;
using AppDiv.CRVS.Application.Features.DeathNotifications.Commands.Update;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Application.Mapper;
using AppDiv.CRVS.Domain.Entities.Notifications;
using MediatR;

namespace AppDiv.CRVS.Application.Features.Lookups.Command.Update
{
    public class UpdateDeathNotificationCommandHandler : IRequestHandler<UpdateDeathNotificationCommand, BaseResponse>
    {
        private readonly IDeathNotificationRepository _deathNotificationRepository;
        private readonly ILookupRepository _lookupRepository;
        private readonly IAddressLookupRepository _addressRepository;
        private readonly IUserRepository _userRepository;
        public UpdateDeathNotificationCommandHandler(IDeathNotificationRepository deathNotificationRepository,
                                                    ILookupRepository lookupRepository,
                                                    IAddressLookupRepository addressRepository,
                                                    IUserRepository userRepository)
        {
            _deathNotificationRepository = deathNotificationRepository;
            this._addressRepository = addressRepository;
            this._userRepository = userRepository;
            this._lookupRepository = lookupRepository;
        }
        public async Task<BaseResponse> Handle(UpdateDeathNotificationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            try
            {
                // Validate the request inputs.
                var validator = new UpdateDeathNotificationCommandValidator(_deathNotificationRepository, _lookupRepository, _addressRepository, _userRepository);
                var validationResult = await validator.ValidateAsync(request, cancellationToken);
                //Check and log validation errors
                if (!validationResult.IsValid)
                {
                    response.BadRequest(validationResult.Errors);
                }
                else
                {
                    // var customerEntity = CustomerMapper.Mapper.Map<Customer>(request);
                    try
                    {
                        // Map to the model entity.
                        var deathNotification = CustomMapper.Mapper.Map<DeathNotification>(request);
                        // Update the data.
                        _deathNotificationRepository.Update(deathNotification);
                        await _deathNotificationRepository.SaveChangesAsync(cancellationToken);
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