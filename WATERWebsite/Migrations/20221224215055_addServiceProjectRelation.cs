using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WATERWebsite.Migrations
{
    public partial class addServiceProjectRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectService");

            migrationBuilder.CreateTable(
                name: "ServiceProject",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProject", x => new { x.ServiceId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_ServiceProject_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceProject_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProject_ProjectId",
                table: "ServiceProject",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "ProjectService",
                columns: table => new
                {
                    ProjectsProjectCode = table.Column<int>(type: "int", nullable: false),
                    ServicesServiceCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectService", x => new { x.ProjectsProjectCode, x.ServicesServiceCode });
                    table.ForeignKey(
                        name: "FK_ProjectService_Project_ProjectsProjectCode",
                        column: x => x.ProjectsProjectCode,
                        principalTable: "Project",
                        principalColumn: "ProjectCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectService_Service_ServicesServiceCode",
                        column: x => x.ServicesServiceCode,
                        principalTable: "Service",
                        principalColumn: "ServiceCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectService_ServicesServiceCode",
                table: "ProjectService",
                column: "ServicesServiceCode");
        }
    }
}
