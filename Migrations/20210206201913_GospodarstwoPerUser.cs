using Microsoft.EntityFrameworkCore.Migrations;

namespace AgroControl.Migrations
{
    public partial class GospodarstwoPerUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Gospodarstwo",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Gospodarstwo");
        }
    }
}
