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
    public class OwnerConfig : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("owner");
            builder.HasKey(c => c.IdOwner);

            builder.HasMany(c => c.properties)
                .WithOne(c => c.owner)
                .HasForeignKey(c => c.idOwner)
                .IsRequired();
        }
    }
}
