using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AgroControl.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gospodarstwo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nazwa = table.Column<string>(nullable: false),
                    Wlasciciel = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gospodarstwo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ObiektyGospodarcze",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nazwa = table.Column<string>(nullable: false),
                    GospodarstwoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObiektyGospodarcze", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ObiektyGospodarcze_Gospodarstwo_GospodarstwoID",
                        column: x => x.GospodarstwoID,
                        principalTable: "Gospodarstwo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObiektyGospodarcze_GospodarstwoID",
                table: "ObiektyGospodarcze",
                column: "GospodarstwoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObiektyGospodarcze");

            migrationBuilder.DropTable(
                name: "Gospodarstwo");
        }
    }
}
