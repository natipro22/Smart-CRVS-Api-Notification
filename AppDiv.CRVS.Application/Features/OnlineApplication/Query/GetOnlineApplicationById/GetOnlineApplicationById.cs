
using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Application.Features.OnlineApplications.Query.GetAllOnlineApplication;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Application.Mapper;
using AppDiv.CRVS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Features.OnlineApplications.Query.GetOnlineApplicationById
{
    // Get birth notificatation by id query.
    public class GetOnlineApplicationById : IRequest<OnlineApplicationDTO>
    {
        public Guid Id { get; private set; }

        public GetOnlineApplicationById(Guid Id)
        {
            this.Id = Id;
        }

    }

    public class GetOnlineApplicationByIdHandler : IRequestHandler<GetOnlineApplicationById, OnlineApplicationDTO>
    {
        private readonly IOnlineApplicationRepository _onlineApplicationRepository;

        public GetOnlineApplicationByIdHandler(IOnlineApplicationRepository onlineApplicationRepository)
        {
            
            _onlineApplicationRepository = onlineApplicationRepository;
        }
        public async Task<OnlineApplicationDTO> Handle(GetOnlineApplicationById request, CancellationToken cancellationToken)
        {
            // get the birth notification by id.
            var selectedOnlineApplication = await _onlineApplicationRepository.GetAsync(request.Id);
            // Map to the DTO.
            return CustomMapper.Mapper.Map<OnlineApplicationDTO>(selectedOnlineApplication);
        }
    }
}