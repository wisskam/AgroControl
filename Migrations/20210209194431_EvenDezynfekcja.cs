using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AgroControl.Migrations
{
    public partial class EvenDezynfekcja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventsDezynfekcja",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    EventType = table.Column<int>(nullable: false),
                    GospodarstwoID = table.Column<int>(nullable: false),
                    DataZabiegu = table.Column<DateTime>(nullable: false),
                    ObiektGospodarczyID = table.Column<int>(nullable: false),
                    ZabiegDlaObiektGospodarczy = table.Column<int>(nullable: false),
                    ZabiegDlaSprzetNarzędzia = table.Column<int>(nullable: false),
                    ZabiegDlaWejscWyjsc = table.Column<int>(nullable: false),
                    SrodekDezynfekujacy = table.Column<string>(nullable: true),
                    IloscPrzyrzadzonegoRoztworu = table.Column<double>(nullable: false),
                    IloscUzytegoRoztworu = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsDezynfekcja", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventsDezynfekcja");
        }
    }
}
