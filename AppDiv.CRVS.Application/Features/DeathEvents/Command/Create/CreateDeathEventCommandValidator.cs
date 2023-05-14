﻿using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Application.Service;
using AppDiv.CRVS.Domain.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Features.DeathEvents.Command.Create
{
    public class CreateDeathEventCommandValidator : AbstractValidator<CreateDeathEventCommand>
    {
        private readonly IEventRepository _repo;
        // private readonly IMediator _mediator;
        public CreateDeathEventCommandValidator(IEventRepository repo, CreateDeathEventCommand request)
        {
            _repo = repo;
            RuleFor(p => p.DeathEvent.FacilityLookupId.ToString()).NotGuidEmpty().ForeignKeyWithLookup(_repo);
            RuleFor(p => p.DeathEvent.FacilityTypeLookupId.ToString()).NotGuidEmpty().ForeignKeyWithLookup(_repo);
            // RuleFor(p => p.DeathEvent.BirthPlaceId.ToString()).NotGuidEmpty().ForeignKeyWithAddress(_repo);
            RuleFor(p => p.DeathEvent.DuringDeath).NotEmpty().NotNull();
            RuleFor(p => p.DeathEvent.PlaceOfFuneral).NotEmpty().NotNull();
            RuleFor(p => p.DeathEvent.DeathNotification.CauseOfDeathInfoTypeLookupId.ToString()).NotGuidEmpty().ForeignKeyWithLookup(_repo);
            // RuleFor(p => p.DeathEvent.DeathNotification.SkilledProfLookupId.ToString()).NotGuidEmpty().ForeignKeyWithLookup(_repo);
            RuleFor(p => p.DeathEvent.DeathNotification.CauseOfDeath).NotEmpty().NotNull();
            RuleFor(p => p.DeathEvent.Event.EventOwener.FirstName.or).NotEmpty().NotNull();
            RuleFor(p => p.DeathEvent.Event.EventOwener.FirstName.am).NotEmpty().NotNull();
            RuleFor(p => p.DeathEvent.Event.EventOwener.SexLookupId.ToString()).NotGuidEmpty().ForeignKeyWithLookup(_repo);
            // RuleFor(p => p.DeathEvent.Event.EventOwener.BirthDate).NotEmpty().NotNull();
            RuleFor(p => p.DeathEvent.Event.EventOwener.PlaceOfBirthLookupId.ToString()).NotGuidEmpty().ForeignKeyWithLookup(_repo);
            RuleFor(p => p.DeathEvent.Event.EventOwener.NationalityLookupId.ToString()).NotGuidEmpty().ForeignKeyWithLookup(_repo);
            RuleFor(p => p.DeathEvent.Event.EventOwener.ResidentAddressId.ToString()).NotGuidEmpty().ForeignKeyWithLookup(_repo);


            if (!string.IsNullOrEmpty(request.DeathEvent.Event.EventRegistrar?.RegistrarInfoId.ToString()) && request.DeathEvent.Event.EventRegistrar != null)
            {
                RuleFor(p => p.DeathEvent.Event.EventRegistrar.RegistrarInfo.Id.ToString()).NotGuidEmpty().ForeignKeyWithPerson(_repo);
                RuleFor(p => p.DeathEvent.Event.EventRegistrar.RegistrarInfo.FirstName.or).NotEmpty().NotNull();
                RuleFor(p => p.DeathEvent.Event.EventRegistrar.RegistrarInfo.FirstName.am).NotEmpty().NotNull();
                RuleFor(p => p.DeathEvent.Event.EventRegistrar.RegistrarInfo.MiddleName.or).NotEmpty().NotNull();
                RuleFor(p => p.DeathEvent.Event.EventRegistrar.RegistrarInfo.MiddleName.am).NotEmpty().NotNull();
                RuleFor(p => p.DeathEvent.Event.EventRegistrar.RegistrarInfo.LastName.or).NotEmpty().NotNull();
                RuleFor(p => p.DeathEvent.Event.EventRegistrar.RegistrarInfo.LastName.am).NotEmpty().NotNull();
                RuleFor(p => p.DeathEvent.Event.EventRegistrar.RegistrarInfo.SexLookupId.ToString()).NotGuidEmpty().ForeignKeyWithLookup(_repo);
                RuleFor(p => p.DeathEvent.Event.EventRegistrar.RegistrarInfo.ResidentAddressId.ToString()).NotGuidEmpty().ForeignKeyWithLookup(_repo);
                // RuleFor(p => p.DeathEvent.Event.EventRegistrar.RegistrarInfo.BirthDate).NotEmpty().NotNull()
                // .Must(date => date < DateTime.Now && date > necw DateTime(1900, 1, 1));
            }
            else
            {
                RuleFor(p => p.DeathEvent.Event.EventRegistrar.RegistrarInfoId.ToString()).NotGuidEmpty().ForeignKeyWithPerson(_repo);
            }

        }

        //private async Task<bool> phoneNumberUnique(CreateCustomerCommand request, CancellationToken token)
        //{
        //    var member = await _repo.GetByIdAsync(request.FirstName);
        //    if (member == null)
        //        return true;
        //    else return false;
        //}

    }
}