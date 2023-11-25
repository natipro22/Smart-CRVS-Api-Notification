using AppDiv.CRVS.Application.Interfaces.Persistence;
using FluentValidation;

namespace AppDiv.CRVS.Application.Features.DeathNotifications.Commands.Create
{
    // Create death notification command validator.
    public class CreateDeathNotificationCommandValidator : AbstractValidator<CreateDeathNotificationCommand>
    {
        private readonly IDeathNotificationRepository _repo;
        private readonly ILookupRepository _lookup;
        private readonly IAddressLookupRepository _address;
        private readonly IUserRepository _user;

        public CreateDeathNotificationCommandValidator(IDeathNotificationRepository repo,
                                                    ILookupRepository lookup, 
                                                    IAddressLookupRepository address,
                                                    IUserRepository user)
        {
            _repo = repo;
            this._address = address;
            this._user = user;
            this._lookup = lookup;
            // Validate the inputs.
            RuleFor(b => b.DeathNotification.FacilityOwnershipId)
                    .MustAsync(CheckLookup)
                    .WithMessage("{PropertyName} Unable to Get the lookup.");

            RuleFor(b => b.DeathNotification.Deceased.SexLookupId)
                    .MustAsync(CheckLookup)
                    .WithMessage("{PropertyName} Unable to Get the lookup.");

            RuleFor(b => b.DeathNotification.FacilityAddressId)
                    .MustAsync(CheckAddress)
                    .WithMessage("{PropertyName} Unable to Get the Address.");
            RuleFor(b => b.DeathNotification.IssuerId)
                    .Must(i => _user.CheckAny(i))
                    .WithMessage("{PropertyName} Unable to Get the User.");
            
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