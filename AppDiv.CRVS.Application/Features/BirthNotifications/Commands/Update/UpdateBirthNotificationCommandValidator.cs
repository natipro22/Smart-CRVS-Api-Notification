using AppDiv.CRVS.Application.Contracts.DTOs.BirthNotifications;
using AppDiv.CRVS.Application.Contracts.Request.BirthNotifications;
using AppDiv.CRVS.Application.Interfaces;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Domain.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Features.BirthNotifications.Commands.Update
{
    // Update birth notification command validator
    public class UpdateBirthNotificationCommandValidator : AbstractValidator<UpdateBirthNotificationCommand>
    {
        private readonly IBirthNotificationRepository _repo;
        private readonly ILookupRepository _lookup;
        private readonly IAddressLookupRepository _address;
        private readonly IUserRepository _user;

        public UpdateBirthNotificationCommandValidator(IBirthNotificationRepository repo, 
                                                    ILookupRepository lookup, 
                                                    IAddressLookupRepository address, IUserRepository user)
        {
            _repo = repo;
            this._address = address;
            this._user = user;
            this._lookup = lookup;

            
            RuleFor(b => b.DeliveryTypeId)
                    .MustAsync(CheckLookup)
                    .WithMessage("{PropertyName} Unable to Get the lookup.");

            RuleFor(b => b.TypeOfBirth)
                    .MustAsync(CheckLookup)
                    .WithMessage("{PropertyName} Unable to Get the lookup.");

            RuleFor(b => b.PlaceOfBirthId)
                    .MustAsync(CheckLookup)
                    .WithMessage("{PropertyName} Unable to Get the lookup.");

            RuleFor(b => b.FacilityOwnershipId)
                    .MustAsync(CheckLookup)
                    .WithMessage("{PropertyName} Unable to Get the lookup.");

            RuleForEach(b => b.Childrens)
                    .MustAsync(CheckGender)
                    .WithMessage("{PropertyName} Unable to Get the Childs Gender.");
        //     RuleForEach(b => b.Childrens)
        //             .MustAsync(CheckChild)
        //             .WithMessage("{PropertyName} Unable to Get the Childs Gender.");

            RuleFor(b => b.FacilityAddressId)
                    .MustAsync(CheckAddress)
                    .WithMessage("{PropertyName} Unable to Get the Address.");

            RuleFor(b => b.IssuerId)
                    .Must(i => _user.CheckAny(i))
                    .WithMessage("{PropertyName} Unable to Get the User.");

            RuleFor(b => b.Id)
                    .MustAsync(async (b, c) => await _repo.AnyAsync(n => n.Id == b))
                    .WithMessage("{PropertyName} Unable to Specified Notification.");
            
        }

        // private async Task<bool> CheckChild(ChildInfoDTO child, CancellationToken token)
        // {
        //     return await _repo.AnyAsync(b => b.Childrens.Select(c => c.Id == child.Id).Count != null);
        // }

        private Task<bool> CheckGender(ChildInfoDTO child, CancellationToken token)
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