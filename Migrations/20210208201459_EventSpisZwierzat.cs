using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AgroControl.Migrations
{
    public partial class EventSpisZwierzat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventsSpisZwierzat",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    EventType = table.Column<int>(nullable: false),
                    GospodarstwoID = table.Column<int>(nullable: false),
                    DataSpisu = table.Column<DateTime>(nullable: false),
                    LiczbaProsiat = table.Column<int>(nullable: false),
                    LiczbaWarchlakow = table.Column<int>(nullable: false),
                    LiczbaTucznikow = table.Column<int>(nullable: false),
                    LiczbaLoch = table.Column<int>(nullable: false),
                    LiczbaLoszek = table.Column<int>(nullable: false),
                    LiczbaKnurow = table.Column<int>(nullable: false),
                    LiczbaKnurkow = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsSpisZwierzat", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventsSpisZwierzat");
        }
    }
}
