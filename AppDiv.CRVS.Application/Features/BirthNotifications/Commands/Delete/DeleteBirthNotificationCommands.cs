using AppDiv.CRVS.Application.Common;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Domain.Entities;
using AppDiv.CRVS.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Features.BirthNotifications.Commands.Delete
{
    // Customer create command with UserBirthNotification response
    public class DeleteBirthNotificationCommand : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }

    }

    // Customer delete command handler with UserBirthNotification response as output
    public class DeleteBirthNotificationCommandHandler : IRequestHandler<DeleteBirthNotificationCommand, BaseResponse>
    {
        private readonly IBirthNotificationRepository _birthNotificationRepository;
        public DeleteBirthNotificationCommandHandler(IBirthNotificationRepository birthNotificationRepository)
        {
            _birthNotificationRepository = birthNotificationRepository;
        }

        public async Task<BaseResponse> Handle(DeleteBirthNotificationCommand request, CancellationToken cancellationToken)
        {
            var res = new BaseResponse();
            try
            {
                var birthNotificationEntity = await _birthNotificationRepository.GetAsync(request.Id);

                await _birthNotificationRepository.DeleteAsync(request.Id);
                await _birthNotificationRepository.SaveChangesAsync(cancellationToken);
                res.Deleted("BirthNotification");
            }
            catch (Exception exp)
            {
                res.BadRequest("Unable to delete the specified birthNotification.");
                throw (new ApplicationException(exp.Message));
            }
            return res;
        }
    }
}
