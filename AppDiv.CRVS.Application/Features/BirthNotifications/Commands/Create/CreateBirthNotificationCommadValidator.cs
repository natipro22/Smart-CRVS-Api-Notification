using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Domain.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Features.BirthNotifications.Commands.Create
{
    public class CreateBirthNotificationComadValidator : AbstractValidator<CreateBirthNotificationCommand>
    {
        private readonly IBirthNotificationRepository _repo;
        public CreateBirthNotificationComadValidator(IBirthNotificationRepository repo)
        {
            _repo = repo;
        }
    }
}