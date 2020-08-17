using Microsoft.EntityFrameworkCore.Migrations;

namespace aplikacja1.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mechanicy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: true),
                    Specjalizacja = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mechanicy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Auta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marka = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Cena = table.Column<int>(nullable: false),
                    OpisUsterki = table.Column<string>(nullable: true),
                    MechanikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auta_Mechanicy_MechanikId",
                        column: x => x.MechanikId,
                        principalTable: "Mechanicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Klienci",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    MechanikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Klienci_Mechanicy_MechanikId",
                        column: x => x.MechanikId,
                        principalTable: "Mechanicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auta_MechanikId",
                table: "Auta",
                column: "MechanikId");

            migrationBuilder.CreateIndex(
                name: "IX_Klienci_MechanikId",
                table: "Klienci",
                column: "MechanikId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auta");

            migrationBuilder.DropTable(
                name: "Klienci");

            migrationBuilder.DropTable(
                name: "Mechanicy");
        }
    }
}
