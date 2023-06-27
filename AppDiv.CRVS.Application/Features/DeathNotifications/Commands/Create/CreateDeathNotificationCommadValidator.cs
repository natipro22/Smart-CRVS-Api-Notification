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
        private readonly ILookupRepository _lookup;
        private readonly IAddressLookupRepository _address;
        public CreateDeathNotificationComadValidator(IDeathNotificationRepository repo,
                                                    ILookupRepository lookup, 
                                                    IAddressLookupRepository address)
        {
            _repo = repo;
            this._address = address;
            this._lookup = lookup;
            RuleFor(b => b.DeathNotification.FacilityOwnershipId)
                    .MustAsync(CheckLookup)
                    .WithMessage("{PropertyName} Unable to Get the lookup.");

            RuleFor(b => b.DeathNotification.PlaceOfDeathId)
                    .MustAsync(CheckLookup)
                    .WithMessage("{PropertyName} Unable to Get the lookup.");

            RuleFor(b => b.DeathNotification.Deceased.SexLookupId)
                    .MustAsync(CheckLookup)
                    .WithMessage("{PropertyName} Unable to Get the lookup.");

            RuleFor(b => b.DeathNotification.FacilityAddressId)
                    .MustAsync(CheckAddress)
                    .WithMessage("{PropertyName} Unable to Get the Address.");
            
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