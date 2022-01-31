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
    public class PropertyTraceConfig : IEntityTypeConfiguration<PropertyTrace>
    {
        public void Configure(EntityTypeBuilder<PropertyTrace> builder)
        {
            builder.ToTable("property_trace");
            builder.HasKey(c => c.idPropertyTrace);

            builder.Property(c => c.dateSale)
                .IsRequired();

            builder.Property(c => c.name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.tax)
                .IsRequired();

            builder.Property(c => c.value)
                .IsRequired();

            builder.HasOne(trace => trace.property)
                .WithMany(property => property.propertyTraces);
        }
    }
}
