using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WATERWebsite.Migrations
{
    public partial class addProjectServicesTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectServices",
                columns: table => new
                {
                    ProjectCode = table.Column<int>(type: "int", nullable: false),
                    ServiceCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectServices", x => new { x.ProjectCode, x.ServiceCode });
                    table.ForeignKey(
                        name: "Fk_ProjectServices_Project",
                        column: x => x.ProjectCode,
                        principalTable: "Project",
                        principalColumn: "ProjectCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_ProjectServices_Service",
                        column: x => x.ServiceCode,
                        principalTable: "Service",
                        principalColumn: "ServiceCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectServices_ServiceCode",
                table: "ProjectServices",
                column: "ServiceCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectServices");
        }
    }
}
