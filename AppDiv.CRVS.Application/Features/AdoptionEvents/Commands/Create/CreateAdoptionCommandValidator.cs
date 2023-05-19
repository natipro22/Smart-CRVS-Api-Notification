using AppDiv.CRVS.Application.Interfaces.Persistence;
using FluentValidation;

namespace AppDiv.CRVS.Application.Features.AdoptionEvents.Commands.Create
{
    public class CreatAdoptionCommandValidator : AbstractValidator<CreateAdoptionCommand>
    {
        private readonly IAdoptionEventRepository _repo;
        private readonly IAddressLookupRepository _address;

        private readonly IPersonalInfoRepository _PersonalInfo;
        public CreatAdoptionCommandValidator(IAdoptionEventRepository repo, IAddressLookupRepository address, IPersonalInfoRepository PersonalInfo)
        {
            _repo = repo;
            _address = address;
            _PersonalInfo = PersonalInfo;
            RuleFor(p => p.Adoption.ApprovedName.am)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("{PropertyName} is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} must not be empty.");
            RuleFor(p => p.Adoption.ApprovedName.or)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("{PropertyName} is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} must not be empty.");
            RuleFor(p => p.Adoption.AdoptiveFather.FirstName.am)
                .NotNull()
                .WithMessage("{PropertyName} is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} must not be empty.");
            RuleFor(p => p.Adoption.AdoptiveFather.FirstName.or)
                .NotNull()
                .WithMessage("{PropertyName} is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} must not be empty.");
            RuleFor(p => p.Adoption.Event.EventSupportingDocuments)
                .NotNull()
                .WithMessage("{PropertyName} is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} must not be empty.");
            RuleFor(e => e.Adoption.BeforeAdoptionAddressId)
              .MustAsync(ValidateForignkeyAddress)
              .WithMessage("A {PropertyName} does not  exists.");
            RuleFor(e => e.Adoption.Event.EventAddressId)
            .MustAsync(ValidateForignkeyAddress)
            .WithMessage("A {PropertyName} does not  exists.");


        }
        private async Task<bool> ValidateForignkeyAddress(Guid request, CancellationToken token)
        {
            var address = await _address.GetByIdAsync(request);
            if (address == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private async Task<bool> ValidateForignkeyPersonalInfo(Guid request, CancellationToken token)
        {
            var PersonalInfo = await _PersonalInfo.GetByIdAsync(request);
            if (PersonalInfo == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}




