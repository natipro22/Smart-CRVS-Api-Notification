using AppDiv.CRVS.Domain.Base;

namespace AppDiv.CRVS.Domain.Entities
{
    public class Witness : BaseAuditableEntity
    {
        public Guid WitnessPersonalInfoId { get; set; }
        public string WitnessFor { get; set;}
        public Guid MarriageEventId { get; set;}
        
        public virtual PersonalInfo WitnessPersonalInfo { get;set;}
        public virtual MarriageEvent MarriageEvent { get; set; }

    }
}