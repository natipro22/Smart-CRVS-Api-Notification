
using AppDiv.CRVS.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using AppDiv.CRVS.Domain.Entities.Notifications;

namespace AppDiv.CRVS.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string? Otp { get; set; }
        public DateTime? OtpExpiredDate { get; set; }
        // public Guid PersonalInfoId { get; set; }
        public Guid IssuerId { get; set; }
        // public Guid AddressId { get; set; }
        // public virtual ICollection<UserGroup> UserGroups { get; set; }
        // public virtual Issuer Issuer { get; set; }
    }
}
