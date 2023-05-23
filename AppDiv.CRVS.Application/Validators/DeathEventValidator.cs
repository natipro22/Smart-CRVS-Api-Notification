using AppDiv.CRVS.Application.Service;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using FluentValidation;
using AppDiv.CRVS.Application.Contracts.Request;

namespace AppDiv.CRVS.Application.Validators
{
    public class DeathEventValidator : AbstractValidator<AddDeathEventRequest>
    {
        private readonly (ILookupRepository Lookup, IPersonalInfoRepository Person) _repo;
        public DeathEventValidator((ILookupRepository Lookup, IPersonalInfoRepository Person) repo)
        {
            _repo = repo;
            RuleFor(p => p.FacilityLookupId.ToString()).NotGuidEmpty().ForeignKeyWithLookup(_repo.Lookup, "FacilityLookupId");
            RuleFor(p => p.FacilityTypeLookupId.ToString()).NotGuidEmpty().ForeignKeyWithLookup(_repo.Lookup, "FacilityTypeLookupId");
            // RuleFor(p => p.BirthCertificateId).NotEmpty().NotNull();
            RuleFor(p => p.PlaceOfFuneral).NotEmpty().NotNull();
            // RuleFor(p => p.Event.RegBookNo).NotEmpty().NotNull();
            // RuleFor(p => p.Event.CivilRegOfficeCode).NotEmpty().NotNull();
            RuleFor(p => p.Event.CertificateId).NotEmpty().NotNull().Must(c =>
                        { return int.TryParse(c.Substring(c.Length - 4), out _) ? true : false; }).WithMessage("The last 4 digit of Death Event certificate must be int.");
            RuleFor(p => p.Event.EventRegDateEt).NotEmpty().NotNull();
            RuleFor(p => p.Event.CivilRegOfficerId.ToString()).NotEmpty().NotNull().ForeignKeyWithPerson(_repo.Person, "CivilRegOfficerId");
        }
    }
}