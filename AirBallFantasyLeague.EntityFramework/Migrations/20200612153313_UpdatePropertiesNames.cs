using Microsoft.EntityFrameworkCore.Migrations;

namespace AirBallFantasyLeague.EntityFramework.Migrations
{
    public partial class UpdatePropertiesNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Steal",
                table: "BasketballPlayerStats",
                newName: "Steals");

            migrationBuilder.RenameColumn(
                name: "Block",
                table: "BasketballPlayerStats",
                newName: "Blocks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Steals",
                table: "BasketballPlayerStats",
                newName: "Steal");

            migrationBuilder.RenameColumn(
                name: "Blocks",
                table: "BasketballPlayerStats",
                newName: "Block");
        }
    }
}
