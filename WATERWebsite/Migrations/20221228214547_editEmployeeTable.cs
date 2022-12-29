using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WATERWebsite.Migrations
{
    public partial class editEmployeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProject");

            migrationBuilder.DropColumn(
                name: "EmployeeDescription",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "Skills",
                table: "Employee",
                newName: "EmployeeDescriptionE");

            migrationBuilder.RenameColumn(
                name: "Links",
                table: "Employee",
                newName: "EmployeeDescriptionA");

            migrationBuilder.AddColumn<int>(
                name: "ProjectCode",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ProjectCode",
                table: "Employee",
                column: "ProjectCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Project_ProjectCode",
                table: "Employee",
                column: "ProjectCode",
                principalTable: "Project",
                principalColumn: "ProjectCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Project_ProjectCode",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_ProjectCode",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ProjectCode",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "EmployeeDescriptionE",
                table: "Employee",
                newName: "Skills");

            migrationBuilder.RenameColumn(
                name: "EmployeeDescriptionA",
                table: "Employee",
                newName: "Links");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeDescription",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

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
                        name: "FK_EmployeeProject_Employee_EmployeesEmployeeCode",
                        column: x => x.EmployeesEmployeeCode,
                        principalTable: "Employee",
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
    }
}
