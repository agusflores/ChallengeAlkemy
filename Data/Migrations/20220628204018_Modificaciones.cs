using Microsoft.EntityFrameworkCore.Migrations;

namespace ChallengeAlkemy.Data.Migrations
{
    public partial class Modificaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Series_Genders_GenderId",
                table: "Series");

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "Series",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Genders_GenderId",
                table: "Series",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Series_Genders_GenderId",
                table: "Series");

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "Series",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Genders_GenderId",
                table: "Series",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
