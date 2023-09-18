using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.Migrations
{
    /// <inheritdoc />
    public partial class AddedHeroToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_HeroToUsers_HeroToUserId",
                table: "Heroes");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_HeroToUserId",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "HeroToUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HeroToUserId",
                table: "Heroes");

            migrationBuilder.AddColumn<int>(
                name: "HeroId",
                table: "HeroToUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeroId",
                table: "HeroToUsers");

            migrationBuilder.AddColumn<int>(
                name: "HeroToUserId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HeroToUserId",
                table: "Heroes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_HeroToUserId",
                table: "Heroes",
                column: "HeroToUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_HeroToUsers_HeroToUserId",
                table: "Heroes",
                column: "HeroToUserId",
                principalTable: "HeroToUsers",
                principalColumn: "Id");
        }
    }
}
