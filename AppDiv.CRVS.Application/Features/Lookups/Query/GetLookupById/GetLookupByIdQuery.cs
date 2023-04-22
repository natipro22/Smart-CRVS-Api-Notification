
using AppDiv.CRVS.Application.Features.Lookups.Query.GetAllLookup;
using AppDiv.CRVS.Application.Mapper;
using AppDiv.CRVS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Features.Lookups.Query.GetLookupById
{
    // Customer GetLookupByIdQuery with  response
    public class GetLookupByIdQuery : IRequest<Lookup>
    {
        public String Id { get; private set; }

        public GetLookupByIdQuery(String Id)
        {
            this.Id = Id;
        }

    }

    public class GetLookupByIdQueryHandler : IRequestHandler<GetLookupByIdQuery, Lookup>
    {
        private readonly IMediator _mediator;

        public GetLookupByIdQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<Lookup> Handle(GetLookupByIdQuery request, CancellationToken cancellationToken)
        {
            var lookups = await _mediator.Send(new GetAllLookupQuery());
            var selectedlookup = lookups.FirstOrDefault(x => x.id == request.Id);
            return CustomMapper.Mapper.Map<Lookup>(selectedlookup);
            // return selectedCustomer;
        }
    }
}