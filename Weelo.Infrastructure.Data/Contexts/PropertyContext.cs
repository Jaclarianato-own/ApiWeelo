using Weelo.Domain;
using Weelo.Infrastructure.Data.Configs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Infrastructure.Data.Contexts
{
    public class PropertyContext: DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Property> properties { get; set; }
        public DbSet<Owner> owners { get; set; }
        public DbSet<PropertyTrace>  propertyTraces { get; set; }
        public DbSet<PropertyImage> propertyImages { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=clarianadb2.co8ijfnxyhj8.us-east-1.rds.amazonaws.com,1433;Initial Catalog=dbproperty;Persist Security Info=False;User ID=jclarianat;Password=Camus2802*;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=true;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new PropertyConfig());
            builder.ApplyConfiguration(new OwnerConfig());
            builder.ApplyConfiguration(new PropertyImageConfig());
            builder.ApplyConfiguration(new PropertyTraceConfig());
            

        }
    }
}
