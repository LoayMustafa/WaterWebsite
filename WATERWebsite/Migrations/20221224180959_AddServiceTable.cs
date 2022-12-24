using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WATERWebsite.Migrations
{
    public partial class AddServiceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProject_Employees_EmployeesEmployeeCode",
                table: "EmployeeProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Servicess",
                table: "Project");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "EmployeeCode");

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceNameE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ServiceOverviewE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceBriefE = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ServiceNameA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ServiceOverviewA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceBriefA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ServicePhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecializedServices = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceCode);
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProject_Employee_EmployeesEmployeeCode",
                table: "EmployeeProject",
                column: "EmployeesEmployeeCode",
                principalTable: "Employee",
                principalColumn: "EmployeeCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProject_Employee_EmployeesEmployeeCode",
                table: "EmployeeProject");

            migrationBuilder.DropTable(
                name: "ProjectService");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Servicess",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProject_Employees_EmployeesEmployeeCode",
                table: "EmployeeProject",
                column: "EmployeesEmployeeCode",
                principalTable: "Employees",
                principalColumn: "EmployeeCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
