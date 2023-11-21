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

namespace AppDiv.CRVS.Application.Features.OnlineApplications.Commands.Delete
{
    // Customer create command with UserOnlineApplication response
    public class DeleteOnlineApplicationCommand : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }

    }

    // Customer delete command handler with UserOnlineApplication response as output
    public class DeleteOnlineApplicationCommandHandler : IRequestHandler<DeleteOnlineApplicationCommand, BaseResponse>
    {
        private readonly IOnlineApplicationRepository _onlineApplicationRepository;
        public DeleteOnlineApplicationCommandHandler(IOnlineApplicationRepository onlineApplicationRepository)
        {
            _onlineApplicationRepository = onlineApplicationRepository;
        }

        public async Task<BaseResponse> Handle(DeleteOnlineApplicationCommand request, CancellationToken cancellationToken)
        {
            var res = new BaseResponse();
            try
            {
                var onlineApplicationEntity = await _onlineApplicationRepository.GetAsync(request.Id);

                await _onlineApplicationRepository.DeleteAsync(request.Id);
                await _onlineApplicationRepository.SaveChangesAsync(cancellationToken);
                res.Deleted("Application");
            }
            catch (Exception exp)
            {
                res.BadRequest("Unable to delete the specified Application.");
                throw (new ApplicationException(exp.Message));
            }
            return res;
        }
    }
}
