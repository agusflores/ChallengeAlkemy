using Microsoft.EntityFrameworkCore.Migrations;

namespace ChallengeAlkemy.Data.Migrations
{
    public partial class EliminacionDeTablaMTMSerieGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SerieGender");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SerieGender",
                columns: table => new
                {
                    SerieId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerieGender", x => new { x.SerieId, x.GenderId });
                    table.ForeignKey(
                        name: "FK_SerieGender_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SerieGender_Series_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SerieGender_GenderId",
                table: "SerieGender",
                column: "GenderId");
        }
    }
}
