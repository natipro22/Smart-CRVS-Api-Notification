
using AppDiv.CRVS.Application.Exceptions;
using AppDiv.CRVS.Application.Features.DivorceEvents.Command.Update;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Utility.Contracts;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppDiv.CRVS.Application.Features.DivorceEvents.Query
{
    // Customer query with List<Customer> response
    public record GetDivorceEventByIdQuery : IRequest<UpdateDivorceEventCommand>
    {
        public Guid Id { get; set; }
    }

    public class GetDivorceEventByIdQueryHandler : IRequestHandler<GetDivorceEventByIdQuery, UpdateDivorceEventCommand>
    {
        private readonly IDivorceEventRepository _DivorceEventRepository;
        private readonly IMapper _mapper;

        public GetDivorceEventByIdQueryHandler(IDivorceEventRepository DivorceEventRepository , IMapper mapper)
        {
            _DivorceEventRepository = DivorceEventRepository;
            _mapper = mapper;
        }
        public async Task<UpdateDivorceEventCommand> Handle(GetDivorceEventByIdQuery request, CancellationToken cancellationToken)
        {
    
        var DivorceEvent =  await _DivorceEventRepository
                .GetAll().Where(m => m.Id == request.Id)
                .Include(m => m.CourtCase)
                .Include(m => m.DivorcedWife)
                .ThenInclude(b => b.ContactInfo)
                .Include(m => m.Event)
                .Include(m => m.Event.EventOwener).ThenInclude(e => e.ContactInfo)
                .Include(m => m.Event.EventSupportingDocuments)
                .Include(m=> m.Event.PaymentExamption).ThenInclude(p => p.SupportingDocuments)
                .ProjectTo<UpdateDivorceEventCommand>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
            if(DivorceEvent == null){
                throw new NotFoundException($"divorce Event with id {request.Id} not found");
            }
            return DivorceEvent;
        }
    }
}