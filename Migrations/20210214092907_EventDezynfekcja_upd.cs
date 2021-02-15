using Microsoft.EntityFrameworkCore.Migrations;

namespace AgroControl.Migrations
{
    public partial class EventDezynfekcja_upd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EventsDezynfekcja_ObiektGospodarczyID",
                table: "EventsDezynfekcja",
                column: "ObiektGospodarczyID");

            migrationBuilder.AddForeignKey(
                name: "FK_EventsDezynfekcja_ObiektyGospodarcze_ObiektGospodarczyID",
                table: "EventsDezynfekcja",
                column: "ObiektGospodarczyID",
                principalTable: "ObiektyGospodarcze",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventsDezynfekcja_ObiektyGospodarcze_ObiektGospodarczyID",
                table: "EventsDezynfekcja");

            migrationBuilder.DropIndex(
                name: "IX_EventsDezynfekcja_ObiektGospodarczyID",
                table: "EventsDezynfekcja");
        }
    }
}
