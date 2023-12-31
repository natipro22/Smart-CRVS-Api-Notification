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

namespace AppDiv.CRVS.Application.Features.AddressLookup.Query.GetAllKebele

{
    // Customer query with List<Customer> response
    public record GetAllKebeleQuery : IRequest<List<KebeleDTO>>
    {
        public int? PageCount { set; get; } = 1!;
        public int? PageSize { get; set; } = 10!;
        public string? SearchString { get; set; }
    }

    public class GetAllKebeleQueryHandler : IRequestHandler<GetAllKebeleQuery, List<KebeleDTO>>
    {
        private readonly IAddressLookupRepository _AddresslookupRepository;

        public GetAllKebeleQueryHandler(IAddressLookupRepository AddresslookupRepository)
        {
            _AddresslookupRepository = AddresslookupRepository;
        }
        public async Task<List<KebeleDTO>> Handle(GetAllKebeleQuery request, CancellationToken cancellationToken)
        {
            var query = _AddresslookupRepository.GetAll()
                                .Include(a => a.ParentAddress)
                               .Where(a => a.AdminLevel == 5 && !a.Status);
            if (!string.IsNullOrEmpty(request.SearchString))
            {
                query = query.Where(a =>
                             EF.Functions.Like(a.AddressNameStr, "%" + request.SearchString + "%")
                             || (a.ParentAddress != null && EF.Functions.Like(a.ParentAddress.AddressNameStr, "%" + request.SearchString + "%"))
                             || ((a.ParentAddress != null && a.ParentAddress.ParentAddress != null) && EF.Functions.Like(a.ParentAddress.ParentAddress.AddressNameStr, "%" + request.SearchString + "%"))
                             || ((a.ParentAddress != null && a.ParentAddress.ParentAddress != null && a.ParentAddress.ParentAddress.ParentAddress != null) && EF.Functions.Like(a.ParentAddress.ParentAddress.ParentAddress.AddressNameStr, "%" + request.SearchString + "%"))
                             || ((a.ParentAddress != null && a.ParentAddress.ParentAddress != null && a.ParentAddress.ParentAddress.ParentAddress != null && a.ParentAddress.ParentAddress.ParentAddress.ParentAddress != null)
                                && EF.Functions.Like(a.ParentAddress.ParentAddress.ParentAddress.ParentAddress.AddressNameStr, "%" + request.SearchString + "%"))
                             );
            }

            return await 
                        query
                        .Select(a => new KebeleDTO
                        {
                            Id = a.Id,
                            Kebele = a.AddressNameLang,
                            Woreda = a.ParentAddress != null ? a.ParentAddress.AddressNameLang : null,
                            Zone = a.ParentAddress != null && a.ParentAddress.ParentAddress != null
                                    ? a.ParentAddress.ParentAddress.AddressNameLang
                                    : null,
                            Region = a.ParentAddress != null && a.ParentAddress.ParentAddress != null && a.ParentAddress.ParentAddress.ParentAddress != null
                                    ? a.ParentAddress.ParentAddress.ParentAddress.AddressNameLang
                                    : null,
                            Country = a.ParentAddress != null && a.ParentAddress.ParentAddress != null && a.ParentAddress.ParentAddress.ParentAddress != null && a.ParentAddress.ParentAddress.ParentAddress.ParentAddress != null
                                    ? a.ParentAddress.ParentAddress.ParentAddress.ParentAddress.AddressNameLang
                                    : null,
                            Code = a.Code,
                            StatisticCode = a.StatisticCode,
                            ParentAddressId = a.ParentAddressId,
                            AreaTypeLookupId = a.AreaTypeLookupId

                        }).ToListAsync();
        }

    }
}