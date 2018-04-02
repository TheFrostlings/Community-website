using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "frostlings");

            migrationBuilder.CreateTable(
                name: "DiscordUsers",
                schema: "frostlings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DiscordTag = table.Column<string>(nullable: false),
                    DiscordUid = table.Column<string>(nullable: false),
                    Summary = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscordUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventTypes",
                schema: "frostlings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                schema: "frostlings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Abbreviation = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    SteamId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialPlatforms",
                schema: "frostlings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Icon = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialPlatforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PollQuestions",
                schema: "frostlings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AllowMultipleAnswers = table.Column<bool>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    PollerId = table.Column<long>(nullable: false),
                    Question = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PollQuestions_DiscordUsers_PollerId",
                        column: x => x.PollerId,
                        principalSchema: "frostlings",
                        principalTable: "DiscordUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                schema: "frostlings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Location = table.Column<string>(nullable: false),
                    OrganizerId = table.Column<long>(nullable: false),
                    Summary = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    TypeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_DiscordUsers_OrganizerId",
                        column: x => x.OrganizerId,
                        principalSchema: "frostlings",
                        principalTable: "DiscordUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_EventTypes_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "frostlings",
                        principalTable: "EventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameServers",
                schema: "frostlings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    GameId = table.Column<long>(nullable: false),
                    Ip = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    OwnerId = table.Column<long>(nullable: false),
                    Summary = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameServers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameServers_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "frostlings",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameServers_DiscordUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "frostlings",
                        principalTable: "DiscordUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GiveAwayKeys",
                schema: "frostlings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AcquiredById = table.Column<long>(nullable: false),
                    GameId = table.Column<long>(nullable: false),
                    Key = table.Column<string>(nullable: false),
                    PlatformId = table.Column<long>(nullable: false),
                    SuppliedById = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiveAwayKeys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiveAwayKeys_DiscordUsers_AcquiredById",
                        column: x => x.AcquiredById,
                        principalSchema: "frostlings",
                        principalTable: "DiscordUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiveAwayKeys_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "frostlings",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiveAwayKeys_SocialPlatforms_PlatformId",
                        column: x => x.PlatformId,
                        principalSchema: "frostlings",
                        principalTable: "SocialPlatforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiveAwayKeys_DiscordUsers_SuppliedById",
                        column: x => x.SuppliedById,
                        principalSchema: "frostlings",
                        principalTable: "DiscordUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                schema: "frostlings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PlatformId = table.Column<long>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    Username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_SocialPlatforms_PlatformId",
                        column: x => x.PlatformId,
                        principalSchema: "frostlings",
                        principalTable: "SocialPlatforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfiles_DiscordUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "frostlings",
                        principalTable: "DiscordUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PollAnswers",
                schema: "frostlings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Answer = table.Column<string>(nullable: false),
                    QuestionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PollAnswers_PollQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "frostlings",
                        principalTable: "PollQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PollVotes",
                schema: "frostlings",
                columns: table => new
                {
                    AnswerId = table.Column<long>(nullable: false),
                    VoterId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollVotes", x => new { x.AnswerId, x.VoterId });
                    table.ForeignKey(
                        name: "FK_PollVotes_PollAnswers_AnswerId",
                        column: x => x.AnswerId,
                        principalSchema: "frostlings",
                        principalTable: "PollAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PollVotes_DiscordUsers_VoterId",
                        column: x => x.VoterId,
                        principalSchema: "frostlings",
                        principalTable: "DiscordUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganizerId",
                schema: "frostlings",
                table: "Events",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_TypeId",
                schema: "frostlings",
                table: "Events",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GameServers_GameId",
                schema: "frostlings",
                table: "GameServers",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameServers_UserId",
                schema: "frostlings",
                table: "GameServers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GiveAwayKeys_AcquiredById",
                schema: "frostlings",
                table: "GiveAwayKeys",
                column: "AcquiredById");

            migrationBuilder.CreateIndex(
                name: "IX_GiveAwayKeys_GameId",
                schema: "frostlings",
                table: "GiveAwayKeys",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GiveAwayKeys_PlatformId",
                schema: "frostlings",
                table: "GiveAwayKeys",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_GiveAwayKeys_SuppliedById",
                schema: "frostlings",
                table: "GiveAwayKeys",
                column: "SuppliedById");

            migrationBuilder.CreateIndex(
                name: "IX_PollAnswers_QuestionId",
                schema: "frostlings",
                table: "PollAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_PollQuestions_PollerId",
                schema: "frostlings",
                table: "PollQuestions",
                column: "PollerId");

            migrationBuilder.CreateIndex(
                name: "IX_PollVotes_VoterId",
                schema: "frostlings",
                table: "PollVotes",
                column: "VoterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_PlatformId",
                schema: "frostlings",
                table: "UserProfiles",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId",
                schema: "frostlings",
                table: "UserProfiles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events",
                schema: "frostlings");

            migrationBuilder.DropTable(
                name: "GameServers",
                schema: "frostlings");

            migrationBuilder.DropTable(
                name: "GiveAwayKeys",
                schema: "frostlings");

            migrationBuilder.DropTable(
                name: "PollVotes",
                schema: "frostlings");

            migrationBuilder.DropTable(
                name: "UserProfiles",
                schema: "frostlings");

            migrationBuilder.DropTable(
                name: "EventTypes",
                schema: "frostlings");

            migrationBuilder.DropTable(
                name: "Games",
                schema: "frostlings");

            migrationBuilder.DropTable(
                name: "PollAnswers",
                schema: "frostlings");

            migrationBuilder.DropTable(
                name: "SocialPlatforms",
                schema: "frostlings");

            migrationBuilder.DropTable(
                name: "PollQuestions",
                schema: "frostlings");

            migrationBuilder.DropTable(
                name: "DiscordUsers",
                schema: "frostlings");
        }
    }
}
