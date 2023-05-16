﻿using AppDiv.CRVS.Application.Exceptions;
using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Application.Mapper;
using AppDiv.CRVS.Domain.Entities;
using AppDiv.CRVS.Domain.Repositories;
using MediatR;
using ApplicationException = AppDiv.CRVS.Application.Exceptions.ApplicationException;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Application.Interfaces;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace AppDiv.CRVS.Application.Features.DeathEvents.Command.Create
{

    public class CreateDeathEventCommandHandler : IRequestHandler<CreateDeathEventCommand, CreateDeathEventCommandResponse>
    {
        private readonly IDeathEventRepository _deathEventRepository;
        private readonly ILookupRepository _lookupRepository;
        private readonly IEventDocumentService _eventDocumentService;
        private readonly IAddressLookupRepository _addressRepository;
        private readonly IPersonalInfoRepository _person;

        public CreateDeathEventCommandHandler(IDeathEventRepository deathEventRepository,
                                              IEventDocumentService eventDocumentService,
                                              ILookupRepository lookupRepository,
                                              IAddressLookupRepository addressRepository,
                                              IPersonalInfoRepository person)
        {
            this._deathEventRepository = deathEventRepository;
            this._eventDocumentService = eventDocumentService;
            this._addressRepository = addressRepository;
            this._lookupRepository = lookupRepository;
            this._person = person;
        }
        public async Task<CreateDeathEventCommandResponse> Handle(CreateDeathEventCommand request, CancellationToken cancellationToken)
        {

            // var customerEntity = CustomerMapper.Mapper.Map<Customer>(request.customer);           

            var createPaymentCommandResponse = new CreateDeathEventCommandResponse();

            var validator = new CreateDeathEventCommandValidator((_lookupRepository, _addressRepository, _person), request);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            //Check and log validation errors
            if (validationResult.Errors.Count > 0)
            {
                createPaymentCommandResponse.Success = false;
                createPaymentCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                    createPaymentCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                createPaymentCommandResponse.Message = createPaymentCommandResponse.ValidationErrors[0];
            }
            if (createPaymentCommandResponse.Success)
            {
                var deathEvent = CustomMapper.Mapper.Map<DeathEvent>(request.DeathEvent);
                deathEvent.Event.EventType = "DeathEvent";
                // logger.LogCritical(deathEvent.Event.CivilRegOfficerId.ToString());
                // logger.LogCritical(deathEvent.Event.EventOwenerId.ToString());

                await _deathEventRepository.InsertOrUpdateAsync(deathEvent, cancellationToken);
                var result = await _deathEventRepository.SaveChangesAsync(cancellationToken);

                var supportingDocuments = deathEvent.Event.EventSupportingDocuments;
                var examptionDocuments = deathEvent.Event.PaymentExamption?.SupportingDocuments;

                _eventDocumentService.saveSupportingDocuments(supportingDocuments, examptionDocuments, "DeathEvents");
            }
            return createPaymentCommandResponse;
        }
    }
}
