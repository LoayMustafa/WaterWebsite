using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WATERWebsite.Migrations
{
    public partial class addProjectsSpecificsTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectNameE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProjectNameA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProjectLocationE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectLocationA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectOwnerE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProjectOwnerA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProjectOperatorE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProjectOperatorA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProjectOverviewE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectOverviewA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectCapacity = table.Column<long>(type: "bigint", maxLength: 25, nullable: true),
                    ProjectPhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectCode);
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectSpecific");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
