using AppDiv.CRVS.Application.Contracts.Request.BirthNotifications;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using FluentValidation;

namespace AppDiv.CRVS.Application.Features.BirthNotifications.Commands.Create
{
    public class CreateBirthNotificationCommandValidator : AbstractValidator<CreateBirthNotificationCommand>
    {
        private readonly IBirthNotificationRepository _repo;
        private readonly ILookupRepository _lookup;
        private readonly IAddressLookupRepository _address;
        private readonly IUserRepository _user;

        public CreateBirthNotificationCommandValidator(IBirthNotificationRepository repo, 
                                                    ILookupRepository lookup, 
                                                    IAddressLookupRepository address, 
                                                    IUserRepository user)
        {
            _repo = repo;
            this._address = address;
            this._user = user;
            this._lookup = lookup;

            // Validate input fields.
            RuleFor(b => b.BirthNotification.DeliveryTypeId)
                    .MustAsync(CheckLookup)
                    .WithMessage("{PropertyName} Unable to Get the lookup.");

            RuleFor(b => b.BirthNotification.TypeOfBirth)
                    .MustAsync(CheckLookup)
                    .WithMessage("{PropertyName} Unable to Get the lookup.");

            RuleFor(b => b.BirthNotification.PlaceOfBirthId)
                    .MustAsync(CheckLookup)
                    .WithMessage("{PropertyName} Unable to Get the lookup.");

            RuleFor(b => b.BirthNotification.FacilityOwnershipId)
                    .MustAsync(CheckLookup)
                    .WithMessage("{PropertyName} Unable to Get the lookup.");

            RuleForEach(b => b.BirthNotification.Childrens)
                    .MustAsync(CheckGender)
                    .WithMessage("{PropertyName} Unable to Get the Childs Gender.");

            RuleFor(b => b.BirthNotification.FacilityAddressId)
                    .MustAsync(CheckAddress)
                    .WithMessage("{PropertyName} Unable to Get the Address.");
            RuleFor(b => b.BirthNotification.IssuerId)
                    .Must(i => _user.CheckAny(i))
                    .WithMessage("{PropertyName} Unable to Get the User.");
        }

        private Task<bool> CheckGender(AddChildInfo child, CancellationToken token)
        {
            return CheckLookup(child.SexLookupId, token);
        }   

        private Task<bool> CheckLookup(Guid id, CancellationToken token)
        {
            return _lookup.AnyAsync(l => l.Id == id);
        }
        private Task<bool> CheckAddress(Guid id, CancellationToken token)
        {
            return _address.AnyAsync(l => l.Id == id);
        }
    }
}