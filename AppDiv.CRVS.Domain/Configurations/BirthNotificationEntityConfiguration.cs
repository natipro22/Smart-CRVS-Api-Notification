using AppDiv.CRVS.Domain.Entities;
using AppDiv.CRVS.Domain.Entities.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppDiv.CRVS.Domain.Configurations
{
    public class BirthNotificationEntityConfiguration : IEntityTypeConfiguration<BirthNotification>
    {
        public void Configure(EntityTypeBuilder<BirthNotification> builder)
        {
            builder.Property(s => s.CreatedBy)
                .HasDefaultValue(Guid.Empty);
            builder.Property(s => s.ModifiedBy)
                .HasDefaultValue(Guid.Empty);
            

            builder.HasOne(m => m.Mother)
               .WithOne(d => d.BirthNotification)
               .HasForeignKey<MotherInfo>(d => d.BirthNotificationId)
               .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(m => m.Childrens)
               .WithOne(d => d.BirthNotification)
               .HasForeignKey(d => d.BirthNotificationId)
               .OnDelete(DeleteBehavior.Cascade);
            
            // builder.HasOne(m => m.Attendant)
            //     .WithMany(d => d.BirthNotifications)
            //     .HasForeignKey(m => m.AttendantId)
            //     .OnDelete(DeleteBehavior.NoAction);
            // builder.HasOne(m => m.Issuer)
            //         .WithMany(i => i.BirthNotification)
            //         .HasForeignKey(d => d.IssuerId)
            //         .IsRequired(true);
        }

    }
}
