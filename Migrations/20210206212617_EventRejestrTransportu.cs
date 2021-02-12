using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AgroControl.Migrations
{
    public partial class EventRejestrTransportu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventRejestrTransportu",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    EventType = table.Column<int>(nullable: false),
                    GospodarstwoID = table.Column<int>(nullable: false),
                    DataIGodzinaWjazdu = table.Column<DateTime>(nullable: false),
                    NazwaLubNrRejestracji = table.Column<string>(nullable: false),
                    CelWjazdu = table.Column<string>(nullable: false),
                    OstatniPobytPojazdu = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRejestrTransportu", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventRejestrTransportu");
        }
    }
}
