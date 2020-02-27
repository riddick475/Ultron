namespace BlazorApp1.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class Initial : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Fixtures");

            migrationBuilder.DropTable("Awayteam");

            migrationBuilder.DropTable("Hometeam");

            migrationBuilder.DropTable("League");

            migrationBuilder.DropTable("Score");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Awayteam",
                table => new
                             {
                                 TeamId = table.Column<int>().Annotation("SqlServer:Identity", "1, 1"),
                                 TeamName = table.Column<string>(nullable: true),
                                 Logo = table.Column<string>(nullable: true)
                             },
                constraints: table => { table.PrimaryKey("PK_Awayteam", x => x.TeamId); });

            migrationBuilder.CreateTable(
                "Hometeam",
                table => new
                             {
                                 TeamId = table.Column<int>().Annotation("SqlServer:Identity", "1, 1"),
                                 TeamName = table.Column<string>(nullable: true),
                                 Logo = table.Column<string>(nullable: true)
                             },
                constraints: table => { table.PrimaryKey("PK_Hometeam", x => x.TeamId); });

            migrationBuilder.CreateTable(
                "League",
                table => new
                             {
                                 LeagueId = table.Column<int>().Annotation("SqlServer:Identity", "1, 1"),
                                 Name = table.Column<string>(nullable: true),
                                 Country = table.Column<string>(nullable: true),
                                 Logo = table.Column<string>(nullable: true),
                                 Flag = table.Column<string>(nullable: true)
                             },
                constraints: table => { table.PrimaryKey("PK_League", x => x.LeagueId); });

            migrationBuilder.CreateTable(
                "Score",
                table => new
                             {
                                 ScoreId = table.Column<int>().Annotation("SqlServer:Identity", "1, 1"),
                                 Halftime = table.Column<string>(nullable: true),
                                 Fulltime = table.Column<string>(nullable: true),
                                 Extratime = table.Column<string>(nullable: true),
                                 Penalty = table.Column<string>(nullable: true)
                             },
                constraints: table => { table.PrimaryKey("PK_Score", x => x.ScoreId); });

            migrationBuilder.CreateTable(
                "Fixtures",
                table => new
                             {
                                 FixtureId = table.Column<int>().Annotation("SqlServer:Identity", "1, 1"),
                                 LeagueId = table.Column<int>(),
                                 EventDate = table.Column<DateTime>(),
                                 EventTimestamp = table.Column<int>(),
                                 FirstHalfStart = table.Column<int>(nullable: true),
                                 SecondHalfStart = table.Column<int>(nullable: true),
                                 Round = table.Column<string>(nullable: true),
                                 Status = table.Column<string>(nullable: true),
                                 StatusShort = table.Column<string>(nullable: true),
                                 Elapsed = table.Column<int>(),
                                 Venue = table.Column<string>(nullable: true),
                                 Referee = table.Column<string>(nullable: true),
                                 HomeTeamId = table.Column<int>(),
                                 AwayteamTeamId = table.Column<int>(nullable: true),
                                 GoalsHomeTeam = table.Column<int>(nullable: true),
                                 GoalsAwayTeam = table.Column<int>(nullable: true),
                                 ScoreId = table.Column<int>(nullable: true)
                             },
                constraints: table =>
                    {
                        table.PrimaryKey("PK_Fixtures", x => x.FixtureId);
                        table.ForeignKey(
                            "FK_Fixtures_Awayteam_AwayteamTeamId",
                            x => x.AwayteamTeamId,
                            "Awayteam",
                            "TeamId",
                            onDelete: ReferentialAction.Restrict);
                        table.ForeignKey(
                            "FK_Fixtures_Hometeam_HomeTeamId",
                            x => x.HomeTeamId,
                            "Hometeam",
                            "TeamId",
                            onDelete: ReferentialAction.Cascade);
                        table.ForeignKey(
                            "FK_Fixtures_League_LeagueId",
                            x => x.LeagueId,
                            "League",
                            "LeagueId",
                            onDelete: ReferentialAction.Cascade);
                        table.ForeignKey(
                            "FK_Fixtures_Score_ScoreId",
                            x => x.ScoreId,
                            "Score",
                            "ScoreId",
                            onDelete: ReferentialAction.Restrict);
                    });

            migrationBuilder.CreateIndex("IX_Fixtures_AwayteamTeamId", "Fixtures", "AwayteamTeamId");

            migrationBuilder.CreateIndex("IX_Fixtures_HomeTeamId", "Fixtures", "HomeTeamId");

            migrationBuilder.CreateIndex("IX_Fixtures_LeagueId", "Fixtures", "LeagueId");

            migrationBuilder.CreateIndex("IX_Fixtures_ScoreId", "Fixtures", "ScoreId");
        }
    }
}