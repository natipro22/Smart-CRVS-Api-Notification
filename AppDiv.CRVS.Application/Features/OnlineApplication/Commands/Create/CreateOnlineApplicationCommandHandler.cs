using AppDiv.CRVS.Application.Mapper;
using AppDiv.CRVS.Domain.Entities.Notifications;
using MediatR;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Domain.Entities.Notification;

namespace AppDiv.CRVS.Application.Features.OnlineApplications.Commands.Create
{

    public class CreateOnlineApplicationCommandHandler : IRequestHandler<CreateOnlineApplicationCommand, CreateOnlineApplicationComandResponse>
    {
        private readonly IOnlineApplicationRepository _onlineApplicationRepository;
        private readonly ILookupRepository _lookupRepository;
        private readonly IAddressLookupRepository _addressRepository;
        private readonly IUserRepository _userRepository;

        public CreateOnlineApplicationCommandHandler(IOnlineApplicationRepository onlineApplicationRepository, 
                                                    ILookupRepository lookupRepository, 
                                                    IAddressLookupRepository addressRepository,
                                                    IUserRepository userRepository)
        {
            _onlineApplicationRepository = onlineApplicationRepository;
            _lookupRepository = lookupRepository;
            _addressRepository = addressRepository;
            _userRepository = userRepository;
        }
        public async Task<CreateOnlineApplicationComandResponse> Handle(CreateOnlineApplicationCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateOnlineApplicationComandResponse();

            try
            {
                // Validate the request inputs.
                var validator = new CreateOnlineApplicationCommandValidator(_onlineApplicationRepository);
                var validationResult = await validator.ValidateAsync(request, cancellationToken);
    
                //Check and log validation errors
                if (!validationResult.IsValid)
                {
                    response.BadRequest(validationResult.Errors);
                }
                else
                {
                    // Map to the model entity.
                    var onlineApplication = CustomMapper.Mapper.Map<OnlineApplication>(request.OnlineApplication);
                    // Insert into the database.
                    await _onlineApplicationRepository.InsertAsync(onlineApplication, cancellationToken);
                    await _onlineApplicationRepository.SaveChangesAsync(cancellationToken);
                    // Set the response to created.
                    response.Created("Application");       
                }
            }
            catch (System.Exception ex)
            {
                // Set the response to Badrequest on exception.
                response.BadRequest(ex.Message);
            }
            return response;
        }
    }
}
