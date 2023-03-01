using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WATERWebsite.Migrations
{
    public partial class DeleteOldServicesTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DivisionSubServices");

            migrationBuilder.DropTable(
                name: "ProjectServices");

            migrationBuilder.DropTable(
                name: "ServiceDivisons");

            migrationBuilder.DropTable(
                name: "SubService");

            migrationBuilder.DropTable(
                name: "Division");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Division",
                columns: table => new
                {
                    DivisionCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivisionBriefA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DivisionBriefE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DivisionNameA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DivisionNameE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.DivisionCode);
                });

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

            migrationBuilder.CreateTable(
                name: "SubService",
                columns: table => new
                {
                    SubServiceCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubServiceBriefA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SubServiceBriefE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SubServiceNameA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SubServiceNameE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubService", x => x.SubServiceCode);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDivisons",
                columns: table => new
                {
                    ServiceCode = table.Column<int>(type: "int", nullable: false),
                    DivisionCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDivisons", x => new { x.ServiceCode, x.DivisionCode });
                    table.ForeignKey(
                        name: "Fk_ServiceDivisions_Division",
                        column: x => x.DivisionCode,
                        principalTable: "Division",
                        principalColumn: "DivisionCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_ServiceDivisions_Service",
                        column: x => x.ServiceCode,
                        principalTable: "Service",
                        principalColumn: "ServiceCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DivisionSubServices",
                columns: table => new
                {
                    DivisionCode = table.Column<int>(type: "int", nullable: false),
                    SubServiceCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionSubServices", x => new { x.DivisionCode, x.SubServiceCode });
                    table.ForeignKey(
                        name: "Fk_DivisionSubServices_Division",
                        column: x => x.DivisionCode,
                        principalTable: "Division",
                        principalColumn: "DivisionCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_DivisionSubServices_SubService",
                        column: x => x.SubServiceCode,
                        principalTable: "SubService",
                        principalColumn: "SubServiceCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DivisionSubServices_SubServiceCode",
                table: "DivisionSubServices",
                column: "SubServiceCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectServices_ServiceCode",
                table: "ProjectServices",
                column: "ServiceCode");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDivisons_DivisionCode",
                table: "ServiceDivisons",
                column: "DivisionCode");
        }
    }
}
