using Microsoft.EntityFrameworkCore.Migrations;

namespace AgroControl.Migrations
{
    public partial class EventPrzegladZabezpieczen_upd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ObiektGospodarczyID",
                table: "EventsPrzegladZabezpieczen",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObiektGospodarczyID",
                table: "EventsPrzegladZabezpieczen");
        }
    }
}
