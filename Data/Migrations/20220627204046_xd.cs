using Microsoft.EntityFrameworkCore.Migrations;

namespace ChallengeAlkemy.Data.Migrations
{
    public partial class xd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSerie_Genders_GenderId",
                table: "CharacterSerie");

            migrationBuilder.DropIndex(
                name: "IX_CharacterSerie_GenderId",
                table: "CharacterSerie");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "CharacterSerie");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Series",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Series_GenderId",
                table: "Series",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Genders_GenderId",
                table: "Series",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Series_Genders_GenderId",
                table: "Series");

            migrationBuilder.DropIndex(
                name: "IX_Series_GenderId",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Series");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "CharacterSerie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSerie_GenderId",
                table: "CharacterSerie",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSerie_Genders_GenderId",
                table: "CharacterSerie",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
