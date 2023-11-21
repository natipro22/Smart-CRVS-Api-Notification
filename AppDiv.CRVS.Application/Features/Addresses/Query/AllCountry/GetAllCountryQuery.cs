using AppDiv.CRVS.Application.Common;
using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Application.Mapper;
using AppDiv.CRVS.Domain.Entities;
using AppDiv.CRVS.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Features.AddressLookup.Query.AllCountry

{
    // Customer query with List<Customer> response
    public record GetAllCountryQuery : IRequest<List<CountryDTO>>
    {
        public int? PageCount { set; get; } = 1!;
        public int? PageSize { get; set; } = 10!;
        public string? SearchString { get; set; }
    }

    public class GetAllCountryQueryHandler : IRequestHandler<GetAllCountryQuery, List<CountryDTO>>
    {
        private readonly IAddressLookupRepository _AddresslookupRepository;

        public GetAllCountryQueryHandler(IAddressLookupRepository AddresslookupRepository)
        {
            _AddresslookupRepository = AddresslookupRepository;
        }
        public async Task<List<CountryDTO>> Handle(GetAllCountryQuery request, CancellationToken cancellationToken)
        {
            var query = _AddresslookupRepository.GetAll()
                                .Where(a => a.AdminLevel == 1 && !a.Status);
            if (!string.IsNullOrEmpty(request.SearchString))
            {
                query = query.Where(a => EF.Functions.Like(a.AddressNameStr, "%" + request.SearchString + "%"));
            }
            return await query
                            .Select(c => new CountryDTO
                            {
                                Id = c.Id,
                                Country = c.AddressNameLang,
                                Code = c.Code,
                                StatisticCode = c.StatisticCode,
                                AreaTypeLookupId = c.AreaTypeLookupId,
                                ParentAddressId = c.ParentAddressId
                            }).ToListAsync();

        }
    }
}