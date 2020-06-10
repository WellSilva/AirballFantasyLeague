using Microsoft.EntityFrameworkCore.Migrations;

namespace AirBallFantasyLeague.EntityFramework.Migrations
{
    public partial class UpdatePlayerPositionRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportPositions_PlayerLeaguePositions_PlayerLeaguePositionId",
                table: "SportPositions");

            migrationBuilder.DropIndex(
                name: "IX_SportPositions_PlayerLeaguePositionId",
                table: "SportPositions");

            migrationBuilder.DropColumn(
                name: "PlayerLeaguePositionId",
                table: "SportPositions");

            migrationBuilder.AddColumn<int>(
                name: "SportPositionId",
                table: "PlayerLeaguePositions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerLeaguePositions_SportPositionId",
                table: "PlayerLeaguePositions",
                column: "SportPositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerLeaguePositions_SportPositions_SportPositionId",
                table: "PlayerLeaguePositions",
                column: "SportPositionId",
                principalTable: "SportPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerLeaguePositions_SportPositions_SportPositionId",
                table: "PlayerLeaguePositions");

            migrationBuilder.DropIndex(
                name: "IX_PlayerLeaguePositions_SportPositionId",
                table: "PlayerLeaguePositions");

            migrationBuilder.DropColumn(
                name: "SportPositionId",
                table: "PlayerLeaguePositions");

            migrationBuilder.AddColumn<long>(
                name: "PlayerLeaguePositionId",
                table: "SportPositions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SportPositions_PlayerLeaguePositionId",
                table: "SportPositions",
                column: "PlayerLeaguePositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SportPositions_PlayerLeaguePositions_PlayerLeaguePositionId",
                table: "SportPositions",
                column: "PlayerLeaguePositionId",
                principalTable: "PlayerLeaguePositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
