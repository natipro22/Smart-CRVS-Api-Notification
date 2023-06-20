using AppDiv.CRVS.Domain.Entities;
using AppDiv.CRVS.Domain.Entities.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppDiv.CRVS.Domain.Configurations
{
    public class DeceasedEntityConfiguration : IEntityTypeConfiguration<Deceased>
    {
        public void Configure(EntityTypeBuilder<Deceased> builder)
        {
            builder.Property(s => s.CreatedBy)
                .HasDefaultValue(Guid.Empty);
            builder.Property(s => s.ModifiedBy)
                .HasDefaultValue(Guid.Empty);

            // builder.HasOne(m => m.DeathNotification)
            //    .WithOne(d => d.Deceased)
            //    .HasForeignKey<Deceased>(d => d.DeathNotificationId)
            //    .IsRequired(false);
            // builder.HasOne(m => m.Registrar)
            //    .WithOne(d => d.DeathNotification)
            //    .HasForeignKey<DeathRegistrar>(d => d.DeathNotificationId)
            //    .IsRequired(true);
            // builder.HasOne(m => m.Issuer)
            //         .WithMany(i => i.DeathNotification)
            //         .HasForeignKey(d => d.IssuerId)
            //         .IsRequired(true);
        }

    }
}
