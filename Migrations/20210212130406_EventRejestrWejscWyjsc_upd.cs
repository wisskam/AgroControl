using Microsoft.EntityFrameworkCore.Migrations;

namespace AgroControl.Migrations
{
    public partial class EventRejestrWejscWyjsc_upd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NazwaNumerBudynku",
                table: "EventsRejestrWejscWyjsc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NazwaNumerBudynku",
                table: "EventsRejestrWejscWyjsc",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
