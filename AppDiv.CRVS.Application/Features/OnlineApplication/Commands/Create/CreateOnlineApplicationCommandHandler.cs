using AppDiv.CRVS.Application.Mapper;
using AppDiv.CRVS.Domain.Entities.Notifications;
using MediatR;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Domain.Entities.Notification;
using AppDiv.CRVS.Utility.Services;

namespace AppDiv.CRVS.Application.Features.OnlineApplications.Commands.Create
{

    public class CreateOnlineApplicationCommandHandler : IRequestHandler<CreateOnlineApplicationCommand, CreateOnlineApplicationComandResponse>
    {
        private readonly IOnlineApplicationRepository _onlineApplicationRepository;
        private readonly ISmsService _smsService;

        public CreateOnlineApplicationCommandHandler(IOnlineApplicationRepository onlineApplicationRepository, ISmsService smsService)
        {
            this._smsService = smsService;
            _onlineApplicationRepository = onlineApplicationRepository;
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
                    onlineApplication.ApplicationCode = await _onlineApplicationRepository.RandomCodeAsync();
                    // Insert into the database.
                    await _onlineApplicationRepository.InsertAsync(onlineApplication, cancellationToken);
                    await _onlineApplicationRepository.SaveChangesAsync(cancellationToken);

                    // send message to the applicant
                    var message = $"Your {onlineApplication.EventType} application successfuly submited." +
                                "Your application code is {onlineApplication.ApplicationCode}.";
                    await _smsService.SendSMS(onlineApplication.Phone, message);
                    // Set the response to created.
                    response.Created("Application");       
                }
            }
            catch (System.Exception ex)
            {
                // Set the response to Badrequest on exception.
                response.BadRequest(ex.Message);
                // throw;
            }
            return response;
        }
    }
}
