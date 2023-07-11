using AppDiv.CRVS.Application.Mapper;
using AppDiv.CRVS.Domain.Entities.Notifications;
using MediatR;
using AppDiv.CRVS.Application.Interfaces.Persistence;

namespace AppDiv.CRVS.Application.Features.BirthNotifications.Commands.Create
{

    public class CreateBirthNotificationCommandHandler : IRequestHandler<CreateBirthNotificationCommand, CreateBirthNotificationComandResponse>
    {
        private readonly IBirthNotificationRepository _birthNotificationRepository;
        private readonly ILookupRepository _lookupRepository;
        private readonly IAddressLookupRepository _addressRepository;
        private readonly IUserRepository _userRepository;

        public CreateBirthNotificationCommandHandler(IBirthNotificationRepository birthNotificationRepository, 
                                                    ILookupRepository lookupRepository, 
                                                    IAddressLookupRepository addressRepository,
                                                    IUserRepository userRepository)
        {
            _birthNotificationRepository = birthNotificationRepository;
            _lookupRepository = lookupRepository;
            _addressRepository = addressRepository;
            _userRepository = userRepository;
        }
        public async Task<CreateBirthNotificationComandResponse> Handle(CreateBirthNotificationCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateBirthNotificationComandResponse();

            try
            {
                // Validate the request inputs.
                var validator = new CreateBirthNotificationCommandValidator(_birthNotificationRepository, _lookupRepository, _addressRepository, _userRepository);
                var validationResult = await validator.ValidateAsync(request, cancellationToken);
    
                //Check and log validation errors
                if (!validationResult.IsValid)
                {
                    response.BadRequest(validationResult.Errors);
                }
                else
                {
                    // Map to the model entity.
                    var birthNotification = CustomMapper.Mapper.Map<BirthNotification>(request.BirthNotification);
                    // Insert into the database.
                    await _birthNotificationRepository.InsertAsync(birthNotification, cancellationToken);
                    await _birthNotificationRepository.SaveChangesAsync(cancellationToken);
                    // Set the response to created.
                    response.Created("Birth Notification");       
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
