﻿using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Application.Contracts.Request;
using AppDiv.CRVS.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Features.DeathEvents.Command.Update
{
    // Customer create command with CustomerResponse
    public class UpdateDeathEventCommand : IRequest<UpdateDeathEventCommandResponse>
    {
        public Guid Id { get; set; }
        public string? BirthCertificateId { get; set; }
        public Guid FacilityTypeLookupId { get; set; }
        public Guid FacilityLookupId { get; set; }
        public string DuringDeath { get; set; }
        public string PlaceOfFuneral { get; set; }
        public AddDeathNotificationRequest? DeathNotification { get; set; }
        public AddEventForDeathRequest Event { get; set; }
    }
}