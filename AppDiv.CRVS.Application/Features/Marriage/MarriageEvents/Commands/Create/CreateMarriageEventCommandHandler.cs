﻿
using AppDiv.CRVS.Application.Mapper;
using AppDiv.CRVS.Domain.Entities;
using MediatR;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AppDiv.CRVS.Application.Features.MarriageEvents.Command.Create
{

    public class CreateMarriageEventCommandHandler : IRequestHandler<CreateMarriageEventCommand, CreateMarriageEventCommandResponse>
    {
        private readonly IMarriageEventRepository _marriageEventRepository;
        private readonly IPersonalInfoRepository _personalInfoRepository;
        private readonly IEventDocumentService _eventDocumentService;
        private readonly ILogger<CreateMarriageEventCommandHandler> logger;

        public CreateMarriageEventCommandHandler(IMarriageEventRepository marriageEventRepository, IPersonalInfoRepository personalInfoRepository, IEventDocumentService eventDocumentService, ILogger<CreateMarriageEventCommandHandler> logger)
        {
            _marriageEventRepository = marriageEventRepository;
            _personalInfoRepository = personalInfoRepository;
            _eventDocumentService = eventDocumentService;
            this.logger = logger;
        }
        public async Task<CreateMarriageEventCommandResponse> Handle(CreateMarriageEventCommand request, CancellationToken cancellationToken)
        {

            var executionStrategy = _marriageEventRepository.Database.CreateExecutionStrategy();
            return await executionStrategy.ExecuteAsync(async () =>
            {

                using (var transaction = _marriageEventRepository.Database.BeginTransaction())
                {

                    try

                    {
                        var CreateMarriageEventCommandResponse = new CreateMarriageEventCommandResponse();

                        var validator = new CreateMarriageEventCommandValidator();
                        var validationResult = await validator.ValidateAsync(request, cancellationToken);

                        //Check and log validation errors
                        if (validationResult.Errors.Count > 0)
                        {
                            CreateMarriageEventCommandResponse.Success = false;
                            CreateMarriageEventCommandResponse.ValidationErrors = new List<string>();
                            foreach (var error in validationResult.Errors)
                                CreateMarriageEventCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                            CreateMarriageEventCommandResponse.Message = CreateMarriageEventCommandResponse.ValidationErrors[0];
                        }
                        if (CreateMarriageEventCommandResponse.Success)
                        {


                            var marriageEvent = CustomMapper.Mapper.Map<MarriageEvent>(request);
           

                            // logger.LogCritical($"yyyyyyyyyy......{request.Event.EventRegistrar.Relationshi}")
                            marriageEvent.Event.EventType = "Marriage";
                            await _marriageEventRepository.InsertOrUpdateAsync(marriageEvent, cancellationToken);


                            await _marriageEventRepository.SaveChangesAsync(cancellationToken);
                            //TODO: //
                            _eventDocumentService.saveSupportingDocuments(marriageEvent.Event.EventSupportingDocuments, marriageEvent.Event.PaymentExamption?.SupportingDocuments, "Marriage");

                        }
                        // return new CreateMarriageEventCommandResponse { Message = "Marriage Event created Successfully" };
                        await transaction.CommitAsync();
                        return CreateMarriageEventCommandResponse;




                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }
                }

            });




        }
    }
}
