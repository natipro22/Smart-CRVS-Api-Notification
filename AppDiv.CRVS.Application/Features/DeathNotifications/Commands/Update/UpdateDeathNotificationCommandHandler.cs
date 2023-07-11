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
                var validator = new UpdateDeathNotificationComadValidator(_deathNotificationRepository, _lookupRepository, _addressRepository, _userRepository);
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
                    // var customerEntity = CustomerMapper.Mapper.Map<Customer>(request);
                    try
                    {
                        var deathNotification = CustomMapper.Mapper.Map<DeathNotification>(request);
                        _deathNotificationRepository.Update(deathNotification);
                        await _deathNotificationRepository.SaveChangesAsync(cancellationToken);
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
                response.BadRequest(ex.Message);
                // throw;
            }
            return response;
        }
    }
}