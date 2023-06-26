using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Domain.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Features.DeathNotifications.Commands.Create
{
    public class CreateDeathNotificationComadValidator : AbstractValidator<CreateDeathNotificationCommand>
    {
        private readonly IDeathNotificationRepository _repo;
        public CreateDeathNotificationComadValidator(IDeathNotificationRepository repo)
        {
            _repo = repo;
        }
    }
}