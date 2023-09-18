using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.Migrations
{
    /// <inheritdoc />
    public partial class addedpowerphoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PowerImageUrl",
                table: "Powers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_HeroToUsers_HeroId",
                table: "HeroToUsers",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroToUsers_UserId",
                table: "HeroToUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HeroToUsers_Heroes_HeroId",
                table: "HeroToUsers",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HeroToUsers_Users_UserId",
                table: "HeroToUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeroToUsers_Heroes_HeroId",
                table: "HeroToUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_HeroToUsers_Users_UserId",
                table: "HeroToUsers");

            migrationBuilder.DropIndex(
                name: "IX_HeroToUsers_HeroId",
                table: "HeroToUsers");

            migrationBuilder.DropIndex(
                name: "IX_HeroToUsers_UserId",
                table: "HeroToUsers");

            migrationBuilder.DropColumn(
                name: "PowerImageUrl",
                table: "Powers");
        }
    }
}
