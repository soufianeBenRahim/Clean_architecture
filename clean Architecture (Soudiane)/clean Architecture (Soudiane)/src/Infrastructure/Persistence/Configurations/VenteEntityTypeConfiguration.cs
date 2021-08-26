using Clean_Architecture_Soufiane.Domain.AggregatesModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;

namespace Clean_Architecture_Soufiane.Infrastructure.Persistence.Confeguration
{
    class VenteEntityTypeConfiguration : IEntityTypeConfiguration<Vente>
    {
        public void Configure(EntityTypeBuilder<Vente> orderConfiguration)
        {
            orderConfiguration.ToTable("Vte_vente");

            orderConfiguration.HasKey(o => o.Id);

            orderConfiguration.Ignore(b => b.DomainEvents);

            orderConfiguration.Property(o => o.Id)
                .UseHiLo("venteseq");

          


            orderConfiguration
                .Property<DateTime>("_venteDate")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("VenteDate")
                .IsRequired();

            orderConfiguration
                .Property<int>("_venteStatusId")
                // .HasField("_orderStatusId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("VenteStatusId")
                .IsRequired();

            

            orderConfiguration.Property<string>("Description").IsRequired(false);

            var navigation = orderConfiguration.Metadata.FindNavigation(nameof(Vente.VenteItems));

            // DDD Patterns comment:
            //Set as field (New since EF 1.1) to access the OrderItem collection property through its field
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

          

      

            orderConfiguration.HasOne(o => o.VenteStatus)
                .WithMany()
                // .HasForeignKey("VenteStatusId");
                .HasForeignKey("_venteStatusId");
        }
    }
}
