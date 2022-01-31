using Weelo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Infrastructure.Data.Configs
{
    public class PropertyImageConfig : IEntityTypeConfiguration<PropertyImage>
    {
        public void Configure(EntityTypeBuilder<PropertyImage> builder)
        {
            builder.ToTable("property_image");
            builder.HasKey(c => c.idPropertyImage);

            builder.Property(c => c.file)
                .IsRequired();

            builder.Property(c => c.enabled)
                .IsRequired();

            builder.Property(c => c.idProperty)
                .IsRequired();

            builder.HasOne(image => image.property)
                .WithMany(property => property.propertyImages);

        }
    }
}
