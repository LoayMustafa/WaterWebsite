using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WATERWebsite.Migrations
{
    public partial class addProjectServiceTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "ProjectSpecific");

            migrationBuilder.CreateTable(
                name: "ProjectService",
                columns: table => new
                {
                    ProjectCode = table.Column<int>(type: "int", nullable: false),
                    ServiceCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectService", x => new { x.ProjectCode, x.ServiceCode });
                    table.ForeignKey(
                        name: "FK_ProjectService_Projects_ProjectCode",
                        column: x => x.ProjectCode,
                        principalTable: "Projects",
                        principalColumn: "ProjectCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectService_Service_ServiceCode",
                        column: x => x.ServiceCode,
                        principalTable: "Service",
                        principalColumn: "ServiceCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectService_ServiceCode",
                table: "ProjectService",
                column: "ServiceCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectService");

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectCapacity = table.Column<long>(type: "bigint", maxLength: 25, nullable: true),
                    ProjectDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProjectDeveloperA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProjectDeveloperE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProjectLocationA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectLocationE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectNameA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProjectNameE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProjectOperatorA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProjectOperatorE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProjectOverviewA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectOverviewE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectOwnerA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProjectOwnerE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProjectPhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectCode);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSpecific",
                columns: table => new
                {
                    ProjectCode = table.Column<int>(type: "int", nullable: false),
                    SpecificCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSpecific", x => new { x.ProjectCode, x.SpecificCode });
                    table.ForeignKey(
                        name: "FK_ProjectSpecific_Projects_ProjectCode",
                        column: x => x.ProjectCode,
                        principalTable: "Projects",
                        principalColumn: "ProjectCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectSpecific_Specifics_SpecificCode",
                        column: x => x.SpecificCode,
                        principalTable: "Specifics",
                        principalColumn: "SpecificsCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSpecific_SpecificCode",
                table: "ProjectSpecific",
                column: "SpecificCode");
        }
    }
}
