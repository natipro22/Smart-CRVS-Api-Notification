using AppDiv.CRVS.Application.Mapper;
using AppDiv.CRVS.Domain.Entities.Notifications;
using MediatR;
using AppDiv.CRVS.Application.Interfaces.Persistence;

namespace AppDiv.CRVS.Application.Features.DeathNotifications.Commands.Create
{

    public class CreateDeathNotificationCommandHandler : IRequestHandler<CreateDeathNotificationCommand, CreateDeathNotificationComandResponse>
    {
        private readonly IDeathNotificationRepository _deathNotificationRepository;
        private readonly ILookupRepository _lookupRepository;
        private readonly IAddressLookupRepository _addressRepository;
        private readonly IUserRepository _userRepository;

        public CreateDeathNotificationCommandHandler(IDeathNotificationRepository deathNotificationRepository,
                                                    ILookupRepository lookupRepository,
                                                    IAddressLookupRepository addressRepository,
                                                    IUserRepository userRepository)
        {
            _deathNotificationRepository = deathNotificationRepository;
            this._addressRepository = addressRepository;
            this._userRepository = userRepository;
            this._lookupRepository = lookupRepository;
        }
        public async Task<CreateDeathNotificationComandResponse> Handle(CreateDeathNotificationCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateDeathNotificationComandResponse();

            try
            {
                // Validate the request inputs.
                var validator = new CreateDeathNotificationCommandValidator(_deathNotificationRepository, _lookupRepository, _addressRepository, _userRepository);
                var validationResult = await validator.ValidateAsync(request, cancellationToken);
    
                //Check and log validation errors
                if (!validationResult.IsValid)
                {
                    response.BadRequest(validationResult.Errors);
                }
                else
                {
                    // Map to the model entity.
                    var deathNotification = CustomMapper.Mapper.Map<DeathNotification>(request.DeathNotification);
                    // Insert into the database.
                    await _deathNotificationRepository.InsertAsync(deathNotification, cancellationToken);
                    await _deathNotificationRepository.SaveChangesAsync(cancellationToken);
                    // Set the response to created.
                    response.Created("Death Notification");     
                }
            }
            catch (System.Exception ex)
            {
                // Set response to BadRequest on exception.
                response.BadRequest(ex.Message);
                // throw;
            }
            return response;
        }
    }
}
