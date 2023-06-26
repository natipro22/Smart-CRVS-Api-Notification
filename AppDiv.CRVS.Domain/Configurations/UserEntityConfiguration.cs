
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppDiv.CRVS.Domain.Entities.Notifications;

namespace AppDiv.CRVS.Domain.Configuration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasMany(m => m.UserGroups)
               .WithMany(m => m.ApplicationUsers);

            builder.HasOne(u => u.Issuer)
            .WithOne(i => i.User)
            .HasForeignKey<ApplicationUser>(u => u.IssuerId);

        }
    }
}
