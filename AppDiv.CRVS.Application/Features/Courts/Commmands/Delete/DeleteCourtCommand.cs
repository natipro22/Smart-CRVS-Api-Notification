using AppDiv.CRVS.Application.Common;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Features.Courts.Commmands.Delete
{
    // Customer create command with BaseResponse response
    public class DeleteCourtCommand : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }

    }

    // Customer delete command handler with BaseResponse response as output
    public class DeleteCourtCommandHandler : IRequestHandler<DeleteCourtCommand, BaseResponse>
    {
        private readonly ICourtRepository _courtRepository;
        public DeleteCourtCommandHandler(ICourtRepository courtRepository)
        {
            _courtRepository = courtRepository;
        }

        public async Task<BaseResponse> Handle(DeleteCourtCommand request, CancellationToken cancellationToken)
        {
            var res = new BaseResponse();
            try
            {
                var courtEntity = await _courtRepository.GetByIdAsync(request.Id);
                await _courtRepository.DeleteAsync(request.Id);
                await _courtRepository.SaveChangesAsync(cancellationToken);
                res.Deleted("Court");
            }
            catch (Exception exp)
            {
                res.BadRequest("Unable to delete the specified court");
            }
            return res;
        }
    }
}
