using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.Migrations
{
    /// <inheritdoc />
    public partial class NewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeroToUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroToUsers", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_HeroToUsers_HeroToUserId",
                table: "Heroes");

            migrationBuilder.DropTable(
                name: "HeroToUsers");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_HeroToUserId",
                table: "Heroes");
        }
    }
}
