using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.Migrations
{
    /// <inheritdoc />
    public partial class manytomanyresolved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Users_UserId",
                table: "Heroes");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_UserId",
                table: "Heroes");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Heroes",
                newName: "HeroToUserId");

            migrationBuilder.AddColumn<int>(
                name: "HeroToUserId",
                table: "Users",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeroToUserId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "HeroToUserId",
                table: "Heroes",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_UserId",
                table: "Heroes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Users_UserId",
                table: "Heroes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
