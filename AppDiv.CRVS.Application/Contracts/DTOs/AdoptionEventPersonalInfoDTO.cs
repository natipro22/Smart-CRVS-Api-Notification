using AppDiv.CRVS.Domain.Entities;
using Newtonsoft.Json.Linq;

namespace AppDiv.CRVS.Application.Contracts.DTOs
{
    public class AdoptionEventPersonalInfoDTO
    {
        public Guid Id { get; set; }
        public JObject FirstName { get; set; }
        public JObject? MiddleName { get; set; }
        public JObject? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? NationalId { get; set; }
        public Guid SexLookupId { get; set; }
        public Guid? PlaceOfBirthLookupId { get; set; }
        public Guid NationalityLookupId { get; set; }
        public Guid? ReligionLookupId { get; set; }
        public Guid? EducationalStatusLookupId { get; set; }
        public Guid? TypeOfWorkLookupId { get; set; }
        public Guid? MarriageStatusLookupId { get; set; }
        public Guid? NationLookupId { get; set; }
    }
}