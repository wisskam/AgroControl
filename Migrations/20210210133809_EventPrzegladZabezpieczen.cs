using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AgroControl.Migrations
{
    public partial class EventPrzegladZabezpieczen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventsPrzegladZabezpieczen",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    EventType = table.Column<int>(nullable: false),
                    GospodarstwoID = table.Column<int>(nullable: false),
                    DataPrzegladu = table.Column<DateTime>(nullable: false),
                    SzczelnoscBudynku = table.Column<int>(nullable: false),
                    SzczelnoscMagazynuPasz = table.Column<int>(nullable: false),
                    SzczelnoscOkienBudynku = table.Column<int>(nullable: false),
                    SzczelnoscOkienMagazynuPasz = table.Column<int>(nullable: false),
                    SzczelnoscDrzwiZewnetrzychBudynku = table.Column<int>(nullable: false),
                    SzczelnoscDrzwiZewnetrzychMagazynuPasz = table.Column<int>(nullable: false),
                    SzczelnoscDrzwiWewnętrzychBudynku = table.Column<int>(nullable: false),
                    SzczelnoscDrzwiWewnętrznychMagazynuPasz = table.Column<int>(nullable: false),
                    PodjeteNaprawyBudynek = table.Column<string>(nullable: true),
                    PodjeteNaprawyMagazynPasz = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsPrzegladZabezpieczen", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventsPrzegladZabezpieczen");
        }
    }
}
