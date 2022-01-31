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
    public class UserConfig: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasKey(c => c.idUser);

            builder.Property("nombre").IsRequired().HasMaxLength(100);
            builder.Property("apellido").IsRequired().HasMaxLength(100);
         


        }

    }
}
