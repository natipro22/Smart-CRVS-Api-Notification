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
        public UpdateBirthNotificationCommandHandler(IBirthNotificationRepository birthNotificationRepository)
        {
            _birthNotificationRepository = birthNotificationRepository;
        }
        public async Task<BaseResponse> Handle(UpdateBirthNotificationCommand request, CancellationToken cancellationToken)
        {
            var response  = new BaseResponse();
            // var customerEntity = CustomerMapper.Mapper.Map<Customer>(request);
            var birthNotification = CustomMapper.Mapper.Map<BirthNotification>(request);
            try
            {
                _birthNotificationRepository.Update(birthNotification);
                await _birthNotificationRepository.SaveChangesAsync(cancellationToken);
                response.Updated("Death Notification");
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }
            return response;
        }
    }
}