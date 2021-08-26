using Clean_Architecture_Soufiane.Domain.AggregatesModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Clean_Architecture_Soufiane.Infrastructure.Persistence.Confeguration
{
    class VenteStatusEntityTypeConfiguration
        : IEntityTypeConfiguration<VenteStatus>
    {
        public void Configure(EntityTypeBuilder<VenteStatus> orderStatusConfiguration)
        {
            orderStatusConfiguration.ToTable("orderstatus");

            orderStatusConfiguration.HasKey(o => o.Id);

            orderStatusConfiguration.Property(o => o.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            orderStatusConfiguration.Property(o => o.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
