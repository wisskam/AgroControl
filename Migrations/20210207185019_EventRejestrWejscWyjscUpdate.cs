using Microsoft.EntityFrameworkCore.Migrations;

namespace AgroControl.Migrations
{
    public partial class EventRejestrWejscWyjscUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumerBudynku",
                table: "EventsRejestrWejscWyjsc");

            migrationBuilder.AddColumn<string>(
                name: "NazwaNumerBudynku",
                table: "EventsRejestrWejscWyjsc",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NazwaNumerBudynku",
                table: "EventsRejestrWejscWyjsc");

            migrationBuilder.AddColumn<int>(
                name: "NumerBudynku",
                table: "EventsRejestrWejscWyjsc",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
