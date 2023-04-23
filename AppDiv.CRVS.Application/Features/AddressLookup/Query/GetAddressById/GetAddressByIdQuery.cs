
using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Application.Features.AddressLookup.Query.GetAllAddress;
using AppDiv.CRVS.Application.Mapper;
using AppDiv.CRVS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Features.AddressLookup.Query.GetAddressById
{
    // Customer GetAddressByIdQuery with  response
    public class GetAddressByIdQuery : IRequest<AddressDTO>
    {
        public Guid Id { get; private set; }

        public GetAddressByIdQuery(Guid Id)
        {
            this.Id = Id;
        }

    }

    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, AddressDTO>
    {
        private readonly IMediator _mediator;

        public GetAddressByIdQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<AddressDTO> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var Addresss = await _mediator.Send(new GetAllAddressQuery());
            var selectedAddress = Addresss.FirstOrDefault(x => x.id == request.Id);
            return CustomMapper.Mapper.Map<AddressDTO>(selectedAddress);
            // return selectedCustomer;
        }
    }
}