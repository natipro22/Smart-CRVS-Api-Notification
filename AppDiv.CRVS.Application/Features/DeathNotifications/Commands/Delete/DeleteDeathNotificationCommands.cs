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

namespace AppDiv.CRVS.Application.Features.DeathNotifications.Commands.Delete
{
    // Customer create command with UserDeathNotification response
    public class DeleteDeathNotificationCommand : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }

    }

    // Customer delete command handler with UserDeathNotification response as output
    public class DeleteDeathNotificationCommandHandler : IRequestHandler<DeleteDeathNotificationCommand, BaseResponse>
    {
        private readonly IDeathNotificationRepository _deathNotificationRepository;
        public DeleteDeathNotificationCommandHandler(IDeathNotificationRepository deathNotificationRepository)
        {
            _deathNotificationRepository = deathNotificationRepository;
        }

        public async Task<BaseResponse> Handle(DeleteDeathNotificationCommand request, CancellationToken cancellationToken)
        {
            var res = new BaseResponse();
            try
            {
                var deathNotificationEntity = await _deathNotificationRepository.GetAsync(request.Id);

                await _deathNotificationRepository.DeleteAsync(request.Id);
                await _deathNotificationRepository.SaveChangesAsync(cancellationToken);
                res.Deleted("DeathNotification");
            }
            catch (Exception exp)
            {
                res.BadRequest("Unable to delete the specified deathNotification.");
                throw (new ApplicationException(exp.Message));
            }
            return res;
        }
    }
}
