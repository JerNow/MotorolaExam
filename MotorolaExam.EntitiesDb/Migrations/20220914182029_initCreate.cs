using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorolaExam.EntitiesDb.Migrations
{
    public partial class initCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MotorolaTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorolaTeams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotoTechStacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Definition = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotoTechStacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotoTeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    YearsOfExpierience = table.Column<int>(type: "int", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MotorolaTeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotoTeamMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotoTeamMembers_MotorolaTeams_MotorolaTeamId",
                        column: x => x.MotorolaTeamId,
                        principalTable: "MotorolaTeams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MotorolaProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MotoTechStackId = table.Column<int>(type: "int", nullable: false),
                    LaunchDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorolaProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotorolaProjects_MotorolaTeams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "MotorolaTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MotorolaProjects_MotoTechStacks_MotoTechStackId",
                        column: x => x.MotoTechStackId,
                        principalTable: "MotoTechStacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MotorolaProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_MotorolaProjects_MotorolaProjectId",
                        column: x => x.MotorolaProjectId,
                        principalTable: "MotorolaProjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MotorolaProjects_MotoTechStackId",
                table: "MotorolaProjects",
                column: "MotoTechStackId");

            migrationBuilder.CreateIndex(
                name: "IX_MotorolaProjects_TeamId",
                table: "MotorolaProjects",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_MotoTeamMembers_MotorolaTeamId",
                table: "MotoTeamMembers",
                column: "MotorolaTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_MotorolaProjectId",
                table: "Review",
                column: "MotorolaProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MotoTeamMembers");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "MotorolaProjects");

            migrationBuilder.DropTable(
                name: "MotorolaTeams");

            migrationBuilder.DropTable(
                name: "MotoTechStacks");
        }
    }
}
