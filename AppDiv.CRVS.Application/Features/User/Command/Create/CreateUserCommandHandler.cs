using AppDiv.CRVS.Application.Interfaces;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Domain;
using AppDiv.CRVS.Domain.Entities;
using AppDiv.CRVS.Domain.Repositories;
using MediatR;

namespace AppDiv.CRVS.Application.Features.User.Command.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IIdentityService _identityService;
        private readonly IPersonalInfoRepository _personalInfoRepository;
        private readonly IContactInfoRepository _contactInfoRepository;
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IIdentityService identityService,
                                        IPersonalInfoRepository personalInfoRepository,
                                        IContactInfoRepository contactInfoRepository,
                                        IUserRepository userRepository)
        {
            _identityService = identityService;
            _userRepository = userRepository;
            _personalInfoRepository = personalInfoRepository;
            _contactInfoRepository = contactInfoRepository;
        }
        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var CreateUserCommadResponse = new CreateUserCommandResponse();

            var validator = new CreateUserCommandValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            //Check and log validation errors
            if (validationResult.Errors.Count > 0)
            {
                CreateUserCommadResponse.Success = false;
                CreateUserCommadResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                    CreateUserCommadResponse.ValidationErrors.Add(error.ErrorMessage);
                CreateUserCommadResponse.Message = CreateUserCommadResponse.ValidationErrors[0];
            }
            if (CreateUserCommadResponse.Success)
            {
                var contact = new ContactInfo
                {
                    Id = request.User.PersonalInfo.ContactInfo.Id,
                    Email = request.User.Email,
                    Phone = request.User.PersonalInfo.ContactInfo.Phone,
                    HouseNumber = request.User.PersonalInfo.ContactInfo.HouseNo,
                    Website = request.User.PersonalInfo.ContactInfo.Website,
                    Linkdin = request.User.PersonalInfo.ContactInfo.Linkdin
                };
                var person = new PersonalInfo
                {
                    Id = request.User.PersonalInfo.Id,
                    FirstName = request.User.PersonalInfo.FirstName,
                    MiddleName = request.User.PersonalInfo.MiddleName,
                    LastName = request.User.PersonalInfo.LastName,
                    BirthDate = request.User.PersonalInfo.BirthDate,
                    NationalId = request.User.PersonalInfo.NationalId,
                    NationalityLookupId = request.User.PersonalInfo.NationalityLookupId,
                    SexLookupId = request.User.PersonalInfo.SexLookupId,
                    PlaceOfBirthLookupId = request.User.PersonalInfo.PlaceOfBirthLookupId,
                    EducationalStatusLookupId = request.User.PersonalInfo.EducationalStatusLookupId,
                    TypeOfWorkLookupId = request.User.PersonalInfo.TypeOfWorkLookupId,
                    MarriageStatusLookupId = request.User.PersonalInfo.MarriageStatusId,
                    AddressId = request.User.PersonalInfo.AddressId,
                    NationLookupId = request.User.PersonalInfo.NationLookupId,
                    TitleLookupId = request.User.PersonalInfo.TitleLookupId,
                    ReligionLookupId = request.User.PersonalInfo.ReligionId,
                    ContactInfo = contact

                };
                //can use this instead of automapper
                var user = new ApplicationUser
                {
                    UserName = request.User.UserName,
                    Email = request.User.Email,
                    PersonalInfo = person,

                };
                var response = await _identityService.createUser(user);
            }
            return CreateUserCommadResponse;

            // request.PersonalInfo.ContactInfo.
            // request.PersonalInfo.
        }
    }
}
