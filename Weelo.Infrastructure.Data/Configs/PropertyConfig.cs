using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Weelo.Infrastructure.Data.Configs
{
    public class PropertyConfig : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("property");
            builder.HasKey(c => c.idProperty);

            builder.Property(c => c.nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.address)
                .IsRequired().IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.address)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.price)
                .IsRequired();

            builder.Property(c => c.idOwner)
                .IsRequired();

            builder.HasOne(property => property.owner)
                .WithMany(owner => owner.properties);

            builder.HasMany(property => property.propertyTraces)
                .WithOne(trace => trace.property)
                .HasForeignKey(trace => trace.idProperty).
                IsRequired();

            builder.HasMany(property => property.propertyImages)
                .WithOne(image => image.property)
                .HasForeignKey(image => image.idProperty)
                .IsRequired();                

        }
    }
}
