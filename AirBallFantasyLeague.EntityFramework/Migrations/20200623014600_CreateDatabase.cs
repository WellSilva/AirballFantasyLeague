using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirBallFantasyLeague.EntityFramework.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    AlteredOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    AlteredById = table.Column<int>(nullable: true),
                    StartDate = table.Column<string>(nullable: true),
                    LogoPath = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SportId = table.Column<int>(nullable: false),
                    NumberTeams = table.Column<int>(nullable: false),
                    ModeId = table.Column<int>(nullable: false),
                    CapSpace = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfficialTeams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    AlteredOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    AlteredById = table.Column<int>(nullable: true),
                    LogoPath = table.Column<string>(nullable: true),
                    SportId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficialTeams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SportPositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    AlteredOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    AlteredById = table.Column<int>(nullable: true),
                    SportId = table.Column<int>(nullable: false),
                    Position = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    AlteredOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    AlteredById = table.Column<int>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    UserEmail = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfficialGames",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    SportId = table.Column<int>(nullable: false),
                    Season = table.Column<int>(nullable: false),
                    HomeOfficialTeamId = table.Column<int>(nullable: false),
                    AwayOfficialTeamId = table.Column<int>(nullable: false),
                    HomeScore = table.Column<int>(nullable: false),
                    AwayScore = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficialGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficialGames_OfficialTeams_AwayOfficialTeamId",
                        column: x => x.AwayOfficialTeamId,
                        principalTable: "OfficialTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfficialGames_OfficialTeams_HomeOfficialTeamId",
                        column: x => x.HomeOfficialTeamId,
                        principalTable: "OfficialTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    AlteredOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    AlteredById = table.Column<int>(nullable: true),
                    OfficialTeamId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Retired = table.Column<bool>(nullable: false),
                    OutSeason = table.Column<bool>(nullable: false),
                    SportId = table.Column<int>(nullable: false),
                    DraftYear = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_OfficialTeams_OfficialTeamId",
                        column: x => x.OfficialTeamId,
                        principalTable: "OfficialTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    AlteredOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    AlteredById = table.Column<int>(nullable: true),
                    LeagueId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    SecondName = table.Column<string>(nullable: true),
                    Mascot = table.Column<string>(nullable: true),
                    LogoPath = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BasketballPlayerStats",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false),
                    Season = table.Column<int>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    Rebounds = table.Column<int>(nullable: false),
                    Assists = table.Column<int>(nullable: false),
                    Steals = table.Column<int>(nullable: false),
                    Blocks = table.Column<int>(nullable: false),
                    Turnover = table.Column<int>(nullable: false),
                    ThreePoints = table.Column<int>(nullable: false),
                    GameId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketballPlayerStats", x => new { x.PlayerId, x.GameId });
                    table.UniqueConstraint("AK_BasketballPlayerStats_GameId_PlayerId", x => new { x.GameId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_BasketballPlayerStats_OfficialGames_GameId1",
                        column: x => x.GameId1,
                        principalTable: "OfficialGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasketballPlayerStats_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerLeaguePositions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LeagueId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    SportPositionId = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    AlteredTime = table.Column<DateTime>(nullable: false),
                    AlteredById = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerLeaguePositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerLeaguePositions_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerLeaguePositions_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerLeaguePositions_SportPositions_SportPositionId",
                        column: x => x.SportPositionId,
                        principalTable: "SportPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeagueGames",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OfficialGameId = table.Column<long>(nullable: false),
                    LeagueId = table.Column<int>(nullable: false),
                    HomeTeamId = table.Column<int>(nullable: false),
                    AwayTeamId = table.Column<int>(nullable: false),
                    HomeScore = table.Column<int>(nullable: false),
                    AwayScore = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeagueGames_Teams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeagueGames_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeagueGames_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeagueGames_OfficialGames_OfficialGameId",
                        column: x => x.OfficialGameId,
                        principalTable: "OfficialGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketballPlayerStats_GameId1",
                table: "BasketballPlayerStats",
                column: "GameId1");

            migrationBuilder.CreateIndex(
                name: "IX_LeagueGames_AwayTeamId",
                table: "LeagueGames",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_LeagueGames_HomeTeamId",
                table: "LeagueGames",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_LeagueGames_LeagueId",
                table: "LeagueGames",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_LeagueGames_OfficialGameId",
                table: "LeagueGames",
                column: "OfficialGameId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialGames_AwayOfficialTeamId",
                table: "OfficialGames",
                column: "AwayOfficialTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialGames_HomeOfficialTeamId",
                table: "OfficialGames",
                column: "HomeOfficialTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerLeaguePositions_LeagueId",
                table: "PlayerLeaguePositions",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerLeaguePositions_PlayerId",
                table: "PlayerLeaguePositions",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerLeaguePositions_SportPositionId",
                table: "PlayerLeaguePositions",
                column: "SportPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_OfficialTeamId",
                table: "Players",
                column: "OfficialTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeagueId",
                table: "Teams",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_UserId",
                table: "Teams",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketballPlayerStats");

            migrationBuilder.DropTable(
                name: "LeagueGames");

            migrationBuilder.DropTable(
                name: "PlayerLeaguePositions");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "OfficialGames");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "SportPositions");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "OfficialTeams");
        }
    }
}
