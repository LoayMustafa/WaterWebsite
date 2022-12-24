using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WATERWebsite.Migrations
{
    public partial class AddProjectTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Projects",
                table: "Employees");

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectNameE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProjectLocationE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectCapacityE = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ProjectOwnerE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProjectOperatorE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProjectDeveloperE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProjectOverviewE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectNameA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProjectLocationA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectCapacityA = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ProjectOwnerA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProjectOperatorA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProjectDeveloperA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProjectOverviewA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectPhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Servicess = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectCode);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProject",
                columns: table => new
                {
                    EmployeesEmployeeCode = table.Column<int>(type: "int", nullable: false),
                    ProjectsProjectCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProject", x => new { x.EmployeesEmployeeCode, x.ProjectsProjectCode });
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Employees_EmployeesEmployeeCode",
                        column: x => x.EmployeesEmployeeCode,
                        principalTable: "Employees",
                        principalColumn: "EmployeeCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Project_ProjectsProjectCode",
                        column: x => x.ProjectsProjectCode,
                        principalTable: "Project",
                        principalColumn: "ProjectCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_ProjectsProjectCode",
                table: "EmployeeProject",
                column: "ProjectsProjectCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProject");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.AddColumn<string>(
                name: "Projects",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
