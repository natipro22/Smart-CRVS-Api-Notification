using AppDiv.CRVS.Application.Interfaces;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Domain.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Features.OnlineApplications.Commands.Update
{
    // Update birth notification command validator
    public class UpdateOnlineApplicationCommandValidator : AbstractValidator<UpdateOnlineApplicationCommand>
    {
        private readonly IOnlineApplicationRepository _repo;

        public UpdateOnlineApplicationCommandValidator(IOnlineApplicationRepository repo)
        {
            _repo = repo;
            
        }
    }
}