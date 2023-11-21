using AppDiv.CRVS.Application.Common;
using AppDiv.CRVS.Application.Features.OnlineApplications.Commands.Update;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Application.Mapper;
using AppDiv.CRVS.Domain.Entities.Notification;
using AppDiv.CRVS.Domain.Entities.Notifications;
using MediatR;

namespace AppDiv.CRVS.Application.Features.Lookups.Command.Update
{
    public class UpdateOnlineApplicationCommandHandler : IRequestHandler<UpdateOnlineApplicationCommand, BaseResponse>
    {
        private readonly IOnlineApplicationRepository _onlineApplicationRepository;
        private readonly ILookupRepository _lookupRepository;
        private readonly IAddressLookupRepository _addressRepository;
        private readonly IUserRepository _userRepository;
        public UpdateOnlineApplicationCommandHandler(IOnlineApplicationRepository onlineApplicationRepository,
                                                    ILookupRepository lookupRepository, 
                                                    IAddressLookupRepository addressRepository,
                                                    IUserRepository userRepository)
        {
            _onlineApplicationRepository = onlineApplicationRepository;
            _lookupRepository = lookupRepository;
            _addressRepository = addressRepository;
            _userRepository = userRepository;
        }
        public async Task<BaseResponse> Handle(UpdateOnlineApplicationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            try
            {
                // Validate the request inputs.
                var validator = new UpdateOnlineApplicationCommandValidator(_onlineApplicationRepository);
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
                        var onlineApplication = CustomMapper.Mapper.Map<OnlineApplication>(request);
                        // Update the data.
                        _onlineApplicationRepository.Update(onlineApplication);
                        await _onlineApplicationRepository.SaveChangesAsync(cancellationToken);
                        // Set the response to updated.
                        response.Updated("Application");
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