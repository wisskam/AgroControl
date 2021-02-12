using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AgroControl.Migrations
{
    public partial class EventRejestrWejscWyjsc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EventRejestrTransportu",
                table: "EventRejestrTransportu");

            migrationBuilder.RenameTable(
                name: "EventRejestrTransportu",
                newName: "EventsRejestrTransportu");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventsRejestrTransportu",
                table: "EventsRejestrTransportu",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "EventsRejestrWejscWyjsc",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    EventType = table.Column<int>(nullable: false),
                    GospodarstwoID = table.Column<int>(nullable: false),
                    DataIGodzinaWejścia = table.Column<DateTime>(nullable: false),
                    NazwaOsobyWchodzacej = table.Column<string>(nullable: false),
                    NazwaFirmy = table.Column<string>(nullable: false),
                    CelWejscia = table.Column<string>(nullable: false),
                    NumerBudynku = table.Column<int>(nullable: false),
                    DataOstatniegoPobytu = table.Column<DateTime>(nullable: false),
                    MiejsceOstatniegoPobytu = table.Column<string>(nullable: false),
                    CzyZastosowanoOchrone = table.Column<bool>(nullable: false),
                    ObiektGospodarczyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsRejestrWejscWyjsc", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventsRejestrWejscWyjsc_ObiektyGospodarcze_ObiektGospodarcz~",
                        column: x => x.ObiektGospodarczyID,
                        principalTable: "ObiektyGospodarcze",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventsRejestrWejscWyjsc_ObiektGospodarczyID",
                table: "EventsRejestrWejscWyjsc",
                column: "ObiektGospodarczyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventsRejestrWejscWyjsc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventsRejestrTransportu",
                table: "EventsRejestrTransportu");

            migrationBuilder.RenameTable(
                name: "EventsRejestrTransportu",
                newName: "EventRejestrTransportu");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventRejestrTransportu",
                table: "EventRejestrTransportu",
                column: "ID");
        }
    }
}
