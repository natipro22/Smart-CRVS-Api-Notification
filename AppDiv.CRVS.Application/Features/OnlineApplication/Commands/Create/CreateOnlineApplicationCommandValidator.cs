using AppDiv.CRVS.Application.Interfaces.Persistence;
using FluentValidation;

namespace AppDiv.CRVS.Application.Features.OnlineApplications.Commands.Create
{
    public class CreateOnlineApplicationCommandValidator : AbstractValidator<CreateOnlineApplicationCommand>
    {
        private readonly IOnlineApplicationRepository _repo;

        public CreateOnlineApplicationCommandValidator(IOnlineApplicationRepository repo)
        {
            _repo = repo;

            
        }
    }
}