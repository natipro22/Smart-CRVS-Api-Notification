using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Domain.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Features.DeathNotifications.Commands.Update
{
    // Update eath notification command validator.
    public class UpdateDeathNotificationCommandValidator : AbstractValidator<UpdateDeathNotificationCommand>
    {
        private readonly IDeathNotificationRepository _repo;
        private readonly ILookupRepository _lookup;
        private readonly IAddressLookupRepository _address;
        private readonly IUserRepository _user;

        public UpdateDeathNotificationCommandValidator(IDeathNotificationRepository repo,
                                                    ILookupRepository lookup, 
                                                    IAddressLookupRepository address,
                                                    IUserRepository user)
        {
            _repo = repo;
            this._address = address;
            this._user = user;
            this._lookup = lookup;
            // Validate the inputs.
            RuleFor(b => b.FacilityOwnershipId)
                    .MustAsync(CheckLookup)
                    .WithMessage("{PropertyName} Unable to Get the lookup.");

            RuleFor(b => b.Deceased.SexLookupId)
                    .MustAsync(CheckLookup)
                    .WithMessage("{PropertyName} Unable to Get the lookup.");

            RuleFor(b => b.FacilityAddressId)
                    .MustAsync(CheckAddress)
                    .WithMessage("{PropertyName} Unable to Get the Address.");
                    
            RuleFor(b => b.IssuerId)
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