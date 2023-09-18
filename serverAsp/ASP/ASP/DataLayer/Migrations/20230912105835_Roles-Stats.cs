using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.Migrations
{
    /// <inheritdoc />
    public partial class RolesStats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AttackType",
                table: "Heroes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Complexity",
                table: "Heroes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Heroes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatsId",
                table: "Heroes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Carry = table.Column<float>(type: "real", nullable: false),
                    Support = table.Column<float>(type: "real", nullable: false),
                    Nuker = table.Column<float>(type: "real", nullable: false),
                    Disabler = table.Column<float>(type: "real", nullable: false),
                    Jungler = table.Column<float>(type: "real", nullable: false),
                    Durable = table.Column<float>(type: "real", nullable: false),
                    Escape = table.Column<float>(type: "real", nullable: false),
                    Pusher = table.Column<float>(type: "real", nullable: false),
                    Initiator = table.Column<float>(type: "real", nullable: false),
                    HeroId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attack = table.Column<float>(type: "real", nullable: false),
                    AttackSpeed = table.Column<float>(type: "real", nullable: false),
                    Range = table.Column<float>(type: "real", nullable: false),
                    Armor = table.Column<float>(type: "real", nullable: false),
                    MagicResist = table.Column<float>(type: "real", nullable: false),
                    MoveSpoeed = table.Column<float>(type: "real", nullable: false),
                    Visibility = table.Column<float>(type: "real", nullable: false),
                    HeroId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stats_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_HeroId",
                table: "Roles",
                column: "HeroId",
                unique: true,
                filter: "[HeroId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_HeroId",
                table: "Stats",
                column: "HeroId",
                unique: true,
                filter: "[HeroId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropColumn(
                name: "AttackType",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "Complexity",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "StatsId",
                table: "Heroes");
        }
    }
}
