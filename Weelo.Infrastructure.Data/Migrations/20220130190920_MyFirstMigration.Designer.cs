// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Weelo.Infrastructure.Data.Contexts;

namespace Weelo.Infrastructure.Data.Migrations
{
    [DbContext(typeof(PropertyContext))]
    [Migration("20220130190920_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Weelo.Domain.Owner", b =>
                {
                    b.Property<Guid>("IdOwner")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("photo")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("IdOwner");

                    b.ToTable("owner");
                });

            modelBuilder.Entity("Weelo.Domain.Property", b =>
                {
                    b.Property<Guid>("idProperty")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("codeInternal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("idOwner")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("idProperty");

                    b.HasIndex("idOwner");

                    b.ToTable("property");
                });

            modelBuilder.Entity("Weelo.Domain.PropertyImage", b =>
                {
                    b.Property<Guid>("idPropertyImage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("enabled")
                        .HasColumnType("bit");

                    b.Property<byte[]>("file")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("idProperty")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("idPropertyImage");

                    b.HasIndex("idProperty");

                    b.ToTable("property_image");
                });

            modelBuilder.Entity("Weelo.Domain.PropertyTrace", b =>
                {
                    b.Property<Guid>("idPropertyTrace")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("dateSale")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("idProperty")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("tax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("idPropertyTrace");

                    b.HasIndex("idProperty");

                    b.ToTable("property_trace");
                });

            modelBuilder.Entity("Weelo.Domain.User", b =>
                {
                    b.Property<Guid>("idUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("idUser");

                    b.ToTable("user");
                });

            modelBuilder.Entity("Weelo.Domain.Property", b =>
                {
                    b.HasOne("Weelo.Domain.Owner", "owner")
                        .WithMany("properties")
                        .HasForeignKey("idOwner")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("owner");
                });

            modelBuilder.Entity("Weelo.Domain.PropertyImage", b =>
                {
                    b.HasOne("Weelo.Domain.Property", "property")
                        .WithMany("propertyImages")
                        .HasForeignKey("idProperty")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("property");
                });

            modelBuilder.Entity("Weelo.Domain.PropertyTrace", b =>
                {
                    b.HasOne("Weelo.Domain.Property", "property")
                        .WithMany("propertyTraces")
                        .HasForeignKey("idProperty")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("property");
                });

            modelBuilder.Entity("Weelo.Domain.Owner", b =>
                {
                    b.Navigation("properties");
                });

            modelBuilder.Entity("Weelo.Domain.Property", b =>
                {
                    b.Navigation("propertyImages");

                    b.Navigation("propertyTraces");
                });
#pragma warning restore 612, 618
        }
    }
}
