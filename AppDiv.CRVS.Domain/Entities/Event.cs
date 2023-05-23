using System.ComponentModel.DataAnnotations.Schema;
using AppDiv.CRVS.Domain.Base;
using EthiopianCalendar;

namespace AppDiv.CRVS.Domain.Entities
{
    public class Event : BaseAuditableEntity
    {
        public string EventType { get; set; }
        public string? RegBookNo { get; set; }
        public string? CivilRegOfficeCode { get; set; }
        public string CertificateId { get; set; }
        public Guid EventOwenerId { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime EventRegDate { get; set; }

        public string EventDateEt { get; set; }
        public string EventRegDateEt { get; set; }

        public Guid EventAddressId { get; set; }
        public string? InformantType { get; set; }
        public Guid CivilRegOfficerId { get; set; }
        public bool IsExampted { get; set; } = false;
        public bool IsPaid { get; set; } = false;
        public bool IsCertified { get; set; } = false;
        public virtual Address EventAddress { get; set; }

        public virtual PersonalInfo EventOwener { get; set; }
        public virtual PersonalInfo CivilRegOfficer { get; set; }
        public virtual BirthEvent BirthEvent { get; set; }
        public virtual Registrar? EventRegistrar { get; set; }
        public virtual DeathEvent DeathEventNavigation { get; set; }
        public virtual AdoptionEvent AdoptionEvent { get; set; }
        public virtual DivorceEvent DivorceEvent { get; set; }
        public virtual PaymentExamption PaymentExamption { get; set; }
        public virtual PaymentRequest EventPaymentRequest { get; set; }
        public virtual ICollection<Certificate> EventCertificates { get; set; }

        public virtual MarriageEvent MarriageEvent { get; set; }
        public virtual ICollection<SupportingDocument> EventSupportingDocuments { get; set; }
        [NotMapped]
        public string? _EventDateEt
        {
            get { return EventDateEt; }
            set
            {
                EventDateEt = value;
                EventDate = new EthiopianDate(DateTime.Parse(EventDateEt).Year, DateTime.Parse(EventDateEt).Month, DateTime.Parse(EventDateEt).Day).ToGregorianDate();
            }
        }
        [NotMapped]
        public string? _EventRegDateEt
        {
            get { return _EventRegDateEt; }
            set
            {
                EventRegDate = new EthiopianDate(DateTime.Parse(EventRegDateEt).Year, DateTime.Parse(EventRegDateEt).Month, DateTime.Parse(EventRegDateEt).Day).ToGregorianDate();
            }
        }
    }
}