using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Weelo.Infrastructure.Data.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "owner",
                columns: table => new
                {
                    IdOwner = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owner", x => x.IdOwner);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    idUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.idUser);
                });

            migrationBuilder.CreateTable(
                name: "property",
                columns: table => new
                {
                    idProperty = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    codeInternal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    year = table.Column<int>(type: "int", nullable: false),
                    idOwner = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_property", x => x.idProperty);
                    table.ForeignKey(
                        name: "FK_property_owner_idOwner",
                        column: x => x.idOwner,
                        principalTable: "owner",
                        principalColumn: "IdOwner",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "property_image",
                columns: table => new
                {
                    idPropertyImage = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    file = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    enabled = table.Column<bool>(type: "bit", nullable: false),
                    idProperty = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_property_image", x => x.idPropertyImage);
                    table.ForeignKey(
                        name: "FK_property_image_property_idProperty",
                        column: x => x.idProperty,
                        principalTable: "property",
                        principalColumn: "idProperty",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "property_trace",
                columns: table => new
                {
                    idPropertyTrace = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dateSale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    idProperty = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_property_trace", x => x.idPropertyTrace);
                    table.ForeignKey(
                        name: "FK_property_trace_property_idProperty",
                        column: x => x.idProperty,
                        principalTable: "property",
                        principalColumn: "idProperty",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_property_idOwner",
                table: "property",
                column: "idOwner");

            migrationBuilder.CreateIndex(
                name: "IX_property_image_idProperty",
                table: "property_image",
                column: "idProperty");

            migrationBuilder.CreateIndex(
                name: "IX_property_trace_idProperty",
                table: "property_trace",
                column: "idProperty");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "property_image");

            migrationBuilder.DropTable(
                name: "property_trace");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "property");

            migrationBuilder.DropTable(
                name: "owner");
        }
    }
}
